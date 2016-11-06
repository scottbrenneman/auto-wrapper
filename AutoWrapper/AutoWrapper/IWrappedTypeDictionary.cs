using System;
using System.Collections.Generic;

namespace AutoWrapper
{
	public interface IWrappedTypeDictionary : IEnumerable<Type>
	{
		bool Registered(Type type);

		bool Registered<TType>() where TType : class;

		string GetTypeNameFor(Type type);

		string GetContractNameFor(Type type);
	}
}