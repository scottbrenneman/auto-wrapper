using System;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class ContractGeneratorOptions : IContractGeneratorOptions, IContractGeneratorOptionsBuilder
	{
		private IContractNamingStrategy _contractNamingStrategy;
		private TypeAttributes _typeAttributes;

		public ContractGeneratorOptions() : this(null) { }

		public ContractGeneratorOptions(IContractNamingStrategy contractNamingStrategy)
		{
			_contractNamingStrategy = contractNamingStrategy ?? new DefaultNamingStrategy();
		}

		public IContractGeneratorOptions AsOptions => this;

		public IContractGeneratorOptionsBuilder AsBuilder => this;


		public IContractGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}
		
		public IContractGeneratorOptionsBuilder WithNamingStrategy(IContractNamingStrategy strategy)
		{
			if (strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_contractNamingStrategy = strategy;

			return this;
		}
		
		public TypeAttributes GetTypeAttributes()
		{
			return _typeAttributes;
		}

		public string GetNameFor(Type type)
		{
			return _contractNamingStrategy.ContractNameFor(type);
		}
	}
}