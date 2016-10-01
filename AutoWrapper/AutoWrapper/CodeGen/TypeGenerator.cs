using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public class TypeGeneratorOptions : ITypeGeneratorOptions, IEnumerable<Type>
	{
		private ITypeNamingStrategy _typeNamingStrategy;
		private IContractNamingStrategy _contractNamingStrategy;
		private readonly IWrapperTypeContainer _wrapperTypeContainer;
		private TypeAttributes _typeAttributes;

		public TypeGeneratorOptions() : this(null, null, null)
		{
		}

		public TypeGeneratorOptions(IWrapperTypeContainer wrapperTypeContainer, ITypeNamingStrategy typeNamingStrategy, IContractNamingStrategy contractNamingStrategy)
		{
			_typeNamingStrategy = typeNamingStrategy ?? new DefaultTypeNamingStrategy();
			_contractNamingStrategy = contractNamingStrategy ?? new DefaultContractNamingStrategy();
			_wrapperTypeContainer = wrapperTypeContainer ?? new WrapperTypeContainer();
		}

		public ITypeGeneratorOptions WrapperFor<TType>()
			where TType : class
		{
			_wrapperTypeContainer.Register<TType>();
			return this;
		}

		public ITypeGeneratorOptions WrapperFor(Type type)
		{
			_wrapperTypeContainer.Register(type);
			return this;
		}

		public ITypeGeneratorOptions AsPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		public ITypeGeneratorOptions AsPartial()
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptions WithName(string name)
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptions WithNamingStrategy(ITypeNamingStrategy strategy)
		{
			if (strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_typeNamingStrategy = strategy;

			return this;
		}

		public ITypeGeneratorOptions WithNamingStrategy(IContractNamingStrategy strategy)
		{
			if(strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_contractNamingStrategy = strategy;

			return this;
		}

		public ITypeGeneratorOptions WithNoContract()
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptions WithNoImplementation()
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptions ExcludingMembersFrom<T>()
		{
			return ((ITypeGeneratorOptions)this).ExcludingMembersFrom(typeof(T));
		}

		public ITypeGeneratorOptions ExcludingMembersFrom(Type type)
		{
			_wrapperTypeContainer.Unregister(type);

			return this;
		}

		public string GetTypeNameFor(Type type)
		{
			return _typeNamingStrategy.TypeNameFor(type);
		}

		public string GetContractNameFor(Type type)
		{
			return _contractNamingStrategy.ContractNameFor(type);
		}

		public static ITypeGeneratorOptions CreateOptionsFor<TType>()
			where TType : class
		{
			return new TypeGeneratorOptions().WrapperFor<TType>();
		}

		public IEnumerator<Type> GetEnumerator()
		{
			return _wrapperTypeContainer.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _wrapperTypeContainer.GetEnumerator();
		}
	}

	public class TypeGenerator : IGenerator
	{
		private readonly ITypeGeneratorOptions _typeGeneratorOptions;

		private readonly IContractGenerator _contractGenerator;

		public TypeGenerator(ITypeGeneratorOptions typeGeneratorOptions, IContractGenerator contractGenerator = null)
		{
			_typeGeneratorOptions = typeGeneratorOptions;
			_contractGenerator = contractGenerator ?? new ContractGenerator();
		}
		
		//public static ITypeGeneratorOptions CreateWrapperFor<TType>()
		//{
		//	var options = new TypeGeneratorOptions();
		//	options.WrapperFor<TType>();
		//	return new TypeGenerator().WrapperFor<TType>();
		//}

		public CodeTypeDeclaration GenerateDeclaration()
		{
			var name = _name;

			if (name == null)
			{
				var namingStrategy = _namingStrategy ?? new DefaultTypeNamingStrategy();

				name = namingStrategy.TypeNameFor(_type);
			}

			var generatedType = new CodeTypeDeclaration(name)
			{
				IsClass = true,
				TypeAttributes = _typeAttributes
			};

			generatedType.Members.AddRange(CompositionMembersFor(_type));

			var methods = _type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false)
				.Where(m => _excludedTypes.Contains(m.DeclaringType) == false);

			foreach (var method in methods)
			{
				var memberMethod = method.ToMemberMethod();

				var invokeExpression =
					new CodeMethodInvokeExpression(
						new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
						memberMethod.Name,
						memberMethod.Parameters.OfType<CodeParameterDeclarationExpression>()
							.Select(p => new CodeVariableReferenceExpression(p.Name))
							.ToArray()
					);

				if (memberMethod.ReturnType.BaseType == "System.Void")
					memberMethod.Statements.Add(invokeExpression);
				else
					memberMethod.Statements.Add(new CodeMethodReturnStatement(invokeExpression));

				generatedType.Members.Add(memberMethod);
			}

			var properties = _type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => _excludedTypes.Contains(p.DeclaringType) == false);

			foreach (var property in properties)
			{
				var memberProperty = property.ToMemberProperty();

				if (memberProperty.HasGet)
				{
					memberProperty.GetStatements.Add(
						new CodeMethodReturnStatement(
							new CodePropertyReferenceExpression(
								new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
								memberProperty.Name))
					);
				}

				if (memberProperty.HasSet)
				{
					memberProperty.SetStatements.Add(
						new CodeAssignStatement(
							new CodePropertyReferenceExpression(
								new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"), memberProperty.Name),
							new CodePropertySetValueReferenceExpression())
					);
				}

				generatedType.Members.Add(memberProperty);
			}

			return generatedType;
		}

		public string GenerateCode()
		{
			var contract = ((IGenerator)_contractGenerator).GenerateDeclaration();

			var generatedType = ((IGenerator)this).GenerateDeclaration();

			using (var provider = CodeDomProvider.CreateProvider("CSharp"))
			using (var writer = new StringWriter())
			{
				var options = new CodeGeneratorOptions { BracingStyle = "C" };

				provider.GenerateCodeFromType(contract, writer, options);
				writer.WriteLine();
				provider.GenerateCodeFromType(generatedType, writer, options);

				return writer.ToString();
			}
		}

		private static CodeTypeMember[] CompositionMembersFor(Type type)
		{
			var members = new CodeTypeMember[2];

			members[0] = new CodeMemberField(type, "_wrapped") { Attributes = MemberAttributes.Private };

			var constructor = new CodeConstructor() { Attributes = MemberAttributes.Public };

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(type, "wrapped"));

			constructor.Statements.Add(
				new CodeAssignStatement(
					new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
					new CodeArgumentReferenceExpression("wrapped"))
			);

			members[1] = constructor;

			return members;
		}
	}
}