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
    public class ContractGenerator : IContractGenerator, IContractGeneratorOptions
    {
		private Type _type;
		private TypeAttributes _typeAttributes = TypeAttributes.Interface;
		private string _name;
		private IContractNamingStrategy _namingStrategy;
		private List<Type> _excludedTypes = new List<Type>();

		public IContractGeneratorOptions ContractFor<TType>()
        {
            return ContractFor(typeof(TType));
        }

        public IContractGeneratorOptions ContractFor(Type type)
        {
            _type = type;

            return this;
        }

        public static IContractGeneratorOptions CreateContractFor<TType>()
		{
			return new ContractGenerator().ContractFor<TType>();
		}

		CodeTypeDeclaration IGenerator.GenerateDeclaration()
		{
			if (_type == null) throw new InvalidOperationException("Specify type by calling ContractFor<TType> prior to generation.");

			var name = _name;

			if (name == null)
			{
				var namingStrategy = _namingStrategy ?? new DefaultContractNamingStrategy();

				name = namingStrategy.ContractNameFor(_type);
			}

			var contract = new CodeTypeDeclaration(name)
			{
				IsInterface = true,
				TypeAttributes = _typeAttributes
			};

			var methods = _type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false)
				.Where(m => _excludedTypes.Contains(m.DeclaringType) == false);

			foreach (var method in methods)
				contract.Members.Add(method.ToMemberMethod());

			var properties = _type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => _excludedTypes.Contains(p.DeclaringType) == false);

			foreach (var property in properties)
				contract.Members.Add(property.ToMemberProperty());

			return contract;
		}

		string IGenerator.GenerateCode()
		{
			var contract = ((IGenerator)this).GenerateDeclaration();

			using (var provider = CodeDomProvider.CreateProvider("CSharp"))
			using (var writer = new StringWriter())
			{
				provider.GenerateCodeFromType(contract, writer, new CodeGeneratorOptions());

				return writer.ToString();
			}
		}

		IContractGeneratorOptions IContractGeneratorOptions.AsPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		IContractGeneratorOptions IContractGeneratorOptions.WithName(string name)
        {
			_name = name;

			return this;
		}

		IContractGeneratorOptions IContractGeneratorOptions.WithNamingStrategy(IContractNamingStrategy strategy)
		{
			_name = null;

			_namingStrategy = strategy;

			return this;
		}

		IContractGeneratorOptions IContractGeneratorOptions.ExcludingMembersFrom<T>()
		{
			return ((IContractGeneratorOptions) this).ExcludingMembersFrom(typeof(T));
		}

		IContractGeneratorOptions IContractGeneratorOptions.ExcludingMembersFrom(Type type)
		{
			if (!_excludedTypes.Contains(type))
				_excludedTypes.Add(type);

			return this;
		}
	}
}