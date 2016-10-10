using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoWrapper
{
	public interface IWrappedTypeContainer : IEnumerable<Type>
	{
		IEnumerable<Type> RegisteredTypes { get; }

		void RegisterAssembly(Assembly assembly);

		void RegisterAssemblyWithType(Type type);

		void Register(Type type, string typeName = null, string contractName = null);

		void Register<TType>(string typeName = null, string contractName = null)
			where TType : class;

		void Unregister<TType>()
			where TType : class;

		void Unregister(Type type);

		bool Registered(Type type);

		bool Registered<TType>() where TType : class;

		string GetTypeNameFor(Type type);

		string GetContractNameFor(Type type);
	}
}