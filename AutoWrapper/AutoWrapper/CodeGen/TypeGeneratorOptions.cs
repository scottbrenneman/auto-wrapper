using System;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class TypeGeneratorOptions : ITypeGeneratorOptions, ITypeGeneratorOptionsBuilder
	{
		private ITypeNamingStrategy _typeNamingStrategy;
		private TypeAttributes _typeAttributes;

		public TypeGeneratorOptions() : this(null)
		{
		}

		public TypeGeneratorOptions(ITypeNamingStrategy typeNamingStrategy)
		{
			_typeNamingStrategy = typeNamingStrategy ?? new DefaultNamingStrategy();
		}

		public ITypeGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;
			return this;
		}

		public ITypeGeneratorOptionsBuilder WithPartial()
		{
			UsePartial = true;
			return this;
		}

		public ITypeGeneratorOptionsBuilder WithNamingStrategy(ITypeNamingStrategy strategy)
		{
			if (strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_typeNamingStrategy = strategy;

			return this;
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

		public bool UsePartial { get; private set; }

		public ITypeGeneratorOptionsBuilder AsBuilder => this;

		public ITypeGeneratorOptions AsOptions => this;
	}
}