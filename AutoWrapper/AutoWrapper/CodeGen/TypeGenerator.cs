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
		private List<Type> _excludedTypes = new List<Type>();

		private readonly IContractGenerator _contractGenerator;

		public TypeGenerator(IContractGenerator contractGenerator = null)
		{
			_contractGenerator = contractGenerator ?? new ContractGenerator();
		}

		public ITypeGeneratorOptions WrapperFor<TType>()
		{
			_type = typeof(TType);

			_contractGenerator.ContractFor<TType>();

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

			generatedType.Members.Add(new CodeMemberField(_type, "_wrapped") { Attributes = MemberAttributes.Private });

			var constructor = new CodeConstructor() { Attributes = MemberAttributes.Public };
			constructor.Parameters.Add(new CodeParameterDeclarationExpression(_type, "wrapped"));
			constructor.Statements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"), new CodeArgumentReferenceExpression("wrapped")));
			generatedType.Members.Add(constructor);

			var methods = _type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false)
				.Where(m => _excludedTypes.Contains(m.DeclaringType) == false);

			foreach (var method in methods)
			{
				var memberMethod = method.ToMemberMethod();

				// TODO: add implementation of generated functions

				generatedType.Members.Add(memberMethod);
			}

			var properties = _type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => _excludedTypes.Contains(p.DeclaringType) == false);

			foreach (var property in properties)
			{
				var memberProperty = property.ToMemberProperty();

				// TODO: add implementation of body

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