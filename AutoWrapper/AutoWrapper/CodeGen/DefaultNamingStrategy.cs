using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class DefaultNamingStrategy : IContractNamingStrategy, ITypeNamingStrategy
	{
		public string ContractNameFor(Type type)
		{
			return 'I' + type.Name;
		}

		public string TypeNameFor(Type type)
		{
			return "Wrapped" + type.Name;
		}
	}
}