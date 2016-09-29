using AutoWrapper.CodeGen.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public sealed class WrapperTypeContainer
	{
		public WrapperTypeContainer(ITypeNamingStrategy typeNamingStrategy, IContractNamingStrategy contractNamingStrategy)
		{
			_typeNamingStrategy = typeNamingStrategy;
			_contractNamingStrategy = contractNamingStrategy;
			_typesToWrap = new List<Type>();
		}

		public IEnumerable<Type> RegisteredTypes => _typesToWrap;

		public void RegisterAssembly(Assembly assembly)
		{
			_typesToWrap.AddRange(
				 assembly.GetTypes()
				 .Where(t => t.IsClass && t.IsPublic && t.IsAbstract == false && t.GetInterfaces().Length == 0)
				 .ToArray()
			);
		}

		public void RegisterAssemblyWithType(Type type)
		{
			RegisterAssembly(Assembly.GetAssembly(type));
		}

		public void Register(Type type)
		{
			_typesToWrap.Add(type);
		}

		public void Register<TType>()
			where TType : class
		{
			Register(typeof(TType));
		}

		public string ResolveTypeName(Type type)
		{
			return _typeNamingStrategy.TypeNameFor(type);
		}

		public string ResolveContractName(Type type)
		{
			return _contractNamingStrategy.ContractNameFor(type);
		}

		private readonly ITypeNamingStrategy _typeNamingStrategy;
		private readonly IContractNamingStrategy _contractNamingStrategy;
		private readonly List<Type> _typesToWrap;
	}
}
