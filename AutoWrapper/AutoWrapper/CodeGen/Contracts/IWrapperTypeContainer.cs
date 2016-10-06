using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IWrapperTypeContainer : IEnumerable<Type>
	{
		IEnumerable<Type> RegisteredTypes { get; }

		void RegisterAssembly(Assembly assembly);

		void RegisterAssemblyWithType(Type type);

		void Register(Type type);

		void Register<TType>()
			where TType : class;

		void Unregister<TType>()
			where TType : class;

		void Unregister(Type type);
	}
}