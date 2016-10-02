using System;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class TypeGeneratorOptions : ITypeGeneratorOptions, ITypeGeneratorOptionsBuilder
	{
		private ITypeNamingStrategy _typeNamingStrategy;
		private IContractNamingStrategy _contractNamingStrategy;
		private TypeAttributes _typeAttributes;

		public TypeGeneratorOptions() : this(null)
		{
		}

		public TypeGeneratorOptions(ITypeNamingStrategy typeNamingStrategy)
		{
			_typeNamingStrategy = typeNamingStrategy ?? new DefaultTypeNamingStrategy();
			
		}

		public ITypeGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		public ITypeGeneratorOptionsBuilder WithPartial()
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptionsBuilder WithName(string name)
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptionsBuilder WithNamingStrategy(ITypeNamingStrategy strategy)
		{
			if (strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_typeNamingStrategy = strategy;

			return this;
		}

		public ITypeGeneratorOptionsBuilder WithNoContract()
		{
			throw new NotImplementedException();
		}

		public ITypeGeneratorOptionsBuilder WithNoImplementation()
		{
			throw new NotImplementedException();
		}

		public string GetNameFor(Type type)
		{
			return _typeNamingStrategy.TypeNameFor(type);
		}
		
		public TypeAttributes GetTypeAttributes()
		{
			return _typeAttributes;
		}

		public ITypeGeneratorOptionsBuilder AsBuilder => this;

		public ITypeGeneratorOptions AsOptions => this;
	}
}