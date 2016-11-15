using System;
using System.Collections.Generic;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class ContractGeneratorOptions : IContractGeneratorOptions, IContractGeneratorOptionsBuilder
	{
		private IContractNamingStrategy _contractNamingStrategy;
		private TypeAttributes _typeAttributes;
		private readonly List<Type> _excludedTypes = new List<Type>();

		public ContractGeneratorOptions() : this(null) { }

		public ContractGeneratorOptions(IContractNamingStrategy contractNamingStrategy)
		{
			_contractNamingStrategy = contractNamingStrategy ?? new DefaultNamingStrategy();
		}

		public bool UsePartial { get; private set; }

		public IContractGeneratorOptions AsOptions => this;

		public IContractGeneratorOptionsBuilder AsBuilder => this;

		public IContractGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		public IContractGeneratorOptionsBuilder WithPartial()
		{
			UsePartial = true;
			return this;
		}

		public IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn<TType>()
		{
			return ExcludeMembersDeclaredOn(typeof(TType));
		}

		public IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn(Type type)
		{
			if (_excludedTypes.Contains(type) == false)
				_excludedTypes.Add(type);

			return this;
		}
		
		public TypeAttributes GetTypeAttributes()
		{
			return _typeAttributes;
		}

		public bool IsExcluded(MemberInfo member)
		{
			return _excludedTypes.Contains(member.DeclaringType);
		}
	}
}