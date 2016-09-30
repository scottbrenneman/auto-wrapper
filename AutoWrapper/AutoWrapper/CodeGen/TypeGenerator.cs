using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public class TypeGenerator : ITypeGeneratorOptions
	{
		private Type _type;
		private TypeAttributes _typeAttributes = TypeAttributes.Class;
		private string _name;
		private ITypeNamingStrategy _namingStrategy;
		private readonly List<Type> _excludedTypes = new List<Type>();

		private readonly IContractGenerator _contractGenerator;

		public TypeGenerator(IContractGenerator contractGenerator = null)
		{
			_contractGenerator = contractGenerator ?? new ContractGenerator();
		}

		public ITypeGeneratorOptions WrapperFor<TType>()
		{
			return WrapperFor(typeof(TType));
		}

		public ITypeGeneratorOptions WrapperFor(Type type)
		{
			_type = type;
			_contractGenerator.ContractFor(type);

			return this;
		}

		public static ITypeGeneratorOptions CreateWrapperFor<TType>()
		{
			return new TypeGenerator().WrapperFor<TType>();
		}

		CodeTypeDeclaration IGenerator.GenerateDeclaration()
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

		string IGenerator.GenerateCode()
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

		ITypeGeneratorOptions ITypeGeneratorOptions.AsPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.AsPartial()
		{
			throw new NotImplementedException();
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.WithName(string name)
		{
			_name = name;

			return this;
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.WithNamingStrategy(ITypeNamingStrategy strategy)
		{
			_name = null;

			_namingStrategy = strategy;

			return this;
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.WithNoContract()
		{
			throw new NotImplementedException();
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.WithNoImplementation()
		{
			throw new NotImplementedException();
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.ExcludingMembersFrom<T>()
		{
			return ((ITypeGeneratorOptions)this).ExcludingMembersFrom(typeof(T));
		}

		ITypeGeneratorOptions ITypeGeneratorOptions.ExcludingMembersFrom(Type type)
		{
			if (!_excludedTypes.Contains(type))
				_excludedTypes.Add(type);

			return this;
		}
	}
}