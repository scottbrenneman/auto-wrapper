using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class TypeGeneratorOptions : ITypeGeneratorOptions, ITypeGeneratorOptionsBuilder
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

		public ITypeGeneratorOptionsBuilder WrapperFor<TType>()
			where TType : class
		{
			_wrapperTypeContainer.Register<TType>();
			return this;
		}

		public ITypeGeneratorOptionsBuilder WrapperFor(Type type)
		{
			_wrapperTypeContainer.Register(type);
			return this;
		}

		public ITypeGeneratorOptionsBuilder AsPublic()
		{
			_typeAttributes |= TypeAttributes.Public;

			return this;
		}

		public ITypeGeneratorOptionsBuilder AsPartial()
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

		public ITypeGeneratorOptionsBuilder WithNamingStrategy(IContractNamingStrategy strategy)
		{
			if(strategy == null)
				throw new ArgumentNullException(nameof(strategy));

			_contractNamingStrategy = strategy;

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

		public ITypeGeneratorOptionsBuilder ExcludingMembersFrom<T>()
		{
			return ExcludingMembersFrom(typeof(T));
		}

		public ITypeGeneratorOptionsBuilder ExcludingMembersFrom(Type type)
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

		public IEnumerator<Type> GetEnumerator()
		{
			return _wrapperTypeContainer.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _wrapperTypeContainer.GetEnumerator();
		}

		public TypeAttributes GetTypeAttributes()
		{
			return _typeAttributes;
		}

		public ITypeGeneratorOptionsBuilder AsBuilder => this;

		public ITypeGeneratorOptions AsOptions => this;

		public static ITypeGeneratorOptions CreateOptionsFor<TType>()
			where TType : class
		{
			var options = new TypeGeneratorOptions();
			options.WrapperFor<TType>();
			return options;
		}
	}
}