﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper
{
	public sealed class WrappedTypeContainer : IWrappedTypeContainer
	{
		public WrappedTypeContainer(ITypeNamingStrategy typeNamingStrategy = null, IContractNamingStrategy contractNamingStrategy = null)
		{
			_typeNamingStrategy = typeNamingStrategy ?? new DefaultNamingStrategy();
			_contractNamingStrategy = contractNamingStrategy ?? new DefaultNamingStrategy();
		}

		public IEnumerable<Type> RegisteredTypes => _typesToWrap.Values.Select(td => td.RegisteredType).ToArray();

		public IWrappedTypeContainer RegisterAssembly(Assembly assembly)
		{
			var typeDefs = assembly.GetTypes()
				.Where(t => t.IsClass && t.IsPublic && t.IsAbstract == false && NotForbiddenBaseType(t))
				.Select(t => new TypeDefinition(t, _typeNamingStrategy.TypeNameFor(t), _contractNamingStrategy.ContractNameFor(t)))
				.ToArray();

			foreach(var td in typeDefs)
				_typesToWrap[td.RegisteredType] = td;

			return this;
		}

		private static bool NotForbiddenBaseType(Type type)
		{
			if (type.IsGenericType)
				type = type.GetGenericTypeDefinition();

			return ! ForbiddenBaseTypes.Any(bt => bt.IsAssignableFrom(type));
		}

		public IWrappedTypeContainer RegisterAssemblyWithType(Type type)
		{
			RegisterAssembly(Assembly.GetAssembly(type));
			return this;
		}

		public IWrappedTypeContainer Register(Type type, string typeName = null, string contractName = null)
		{
			if (string.IsNullOrWhiteSpace(typeName))
				typeName = _typeNamingStrategy.TypeNameFor(type);

			if (string.IsNullOrWhiteSpace(contractName))
				contractName = _contractNamingStrategy.ContractNameFor(type);

			_typesToWrap[type] = new TypeDefinition(type, typeName, contractName);
			return this;
		}

		public IWrappedTypeContainer Register<TType>(string typeName = null, string contractName = null)
			where TType : class
		{
			Register(typeof(TType), typeName, contractName);
			return this;
		}

		public IWrappedTypeContainer Unregister<TType>()
			where TType : class
		{
			_typesToWrap.Remove(typeof(TType));
			return this;
		}

		public IWrappedTypeContainer Unregister(Type type)
		{
			_typesToWrap.Remove(type);
			return this;
		}

		public bool Registered(Type type) => _typesToWrap.ContainsKey(type);
		public bool Registered<TType>() where TType : class => Registered(typeof(TType));

		public bool Registered(string name)
		{
			return _typesToWrap.Values.Any(td => td.ContractName == name || td.TypeName == name);
		}

		public string GetTypeNameFor(Type type) => _typesToWrap[type].TypeName;
		public string GetContractNameFor(Type type) => _typesToWrap[type].ContractName;

		public string GetTypeNameFor(string contractName)
		{
			return _typesToWrap.Values.FirstOrDefault(td => td.ContractName == contractName).TypeName;
		}

		public IEnumerator<Type> GetEnumerator() => RegisteredTypes.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => RegisteredTypes.GetEnumerator();

		private readonly ITypeNamingStrategy _typeNamingStrategy;
		private readonly IContractNamingStrategy _contractNamingStrategy;
		private readonly Dictionary<Type, TypeDefinition> _typesToWrap = new Dictionary<Type, TypeDefinition>();

		public static readonly List<Type> ForbiddenBaseTypes = new List<Type>
		{
			typeof(Attribute)
		};

		internal struct TypeDefinition
		{
			public TypeDefinition(Type registeredType, string typeName, string contractName)
			{
				if (registeredType == null)
					throw new ArgumentNullException(nameof(registeredType));

				if (string.IsNullOrWhiteSpace(typeName))
					throw new ArgumentException("Type Name must be non-null and not empty.", nameof(typeName));

				if (string.IsNullOrWhiteSpace(contractName))
					throw new ArgumentException("Contract Name must be non-null and not empty.", nameof(contractName));

				RegisteredType = registeredType;
				TypeName = typeName;
				ContractName = contractName;
			}

			public readonly Type RegisteredType;

			public readonly string TypeName;

			public readonly string ContractName;
		}
	}
}