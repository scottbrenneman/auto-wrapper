using System;
using System.Collections.Generic;

namespace AutoWrapper
{
	public interface IWrappedTypeDictionary : IEnumerable<Type>
	{
		bool Registered(Type type);

		bool Registered<TType>() where TType : class;

		bool Registered(string name);

		string GetTypeNameFor(Type type);

		string GetTypeNameFor(string contractName);

		string GetContractNameFor(Type type);
	}
}