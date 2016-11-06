using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoWrapper
{
	public interface IWrappedTypeContainer : IWrappedTypeDictionary
	{
		IEnumerable<Type> RegisteredTypes { get; }

		IWrappedTypeContainer RegisterAssembly(Assembly assembly);

		IWrappedTypeContainer RegisterAssemblyWithType(Type type);

		IWrappedTypeContainer Register(Type type, string typeName = null, string contractName = null);

		IWrappedTypeContainer Register<TType>(string typeName = null, string contractName = null)
			where TType : class;

		IWrappedTypeContainer Unregister<TType>()
			where TType : class;

		IWrappedTypeContainer Unregister(Type type);
	}
}