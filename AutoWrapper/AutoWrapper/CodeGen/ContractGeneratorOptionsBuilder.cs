using System;
using System.Collections.Generic;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class ContractGeneratorOptionsBuilder : IContractGeneratorOptionsBuilder, IContractGeneratorOptions
	{
		private IContractNamingStrategy _contractNamingStrategy;
		private TypeAttributes _typeAttributes;
		private readonly List<Type> _excludedTypes = new List<Type>();

		public ContractGeneratorOptionsBuilder(IContractNamingStrategy contractNamingStrategy = null)
		{
			_contractNamingStrategy = contractNamingStrategy ?? new DefaultNamingStrategy();
		}

		public IContractGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;
			return this;
		}

		public IContractGeneratorOptionsBuilder WithPartial()
		{
			_usePartial = true;
			return this;
		}

		public IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn<TType>() => ExcludeMembersDeclaredOn(typeof(TType));

		public IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn(Type type)
		{
			if (_excludedTypes.Contains(type) == false)
				_excludedTypes.Add(type);

			return this;
		}

		public IContractGeneratorOptions Build() => this;

		TypeAttributes IContractGeneratorOptions.GetTypeAttributes() => _typeAttributes;

		bool IContractGeneratorOptions.IsExcluded(MemberInfo member) => _excludedTypes.Contains(member.DeclaringType);

		private bool _usePartial;
		bool IContractGeneratorOptions.UsePartial => _usePartial;
	}
}