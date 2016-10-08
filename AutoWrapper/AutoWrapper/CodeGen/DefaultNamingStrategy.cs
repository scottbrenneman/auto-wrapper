using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class DefaultNamingStrategy : IContractNamingStrategy, ITypeNamingStrategy
	{
		public string ContractNameFor(Type type)
		{
			return $"I{type.Name}Wrapper";
		}

		public string TypeNameFor(Type type)
		{
			return $"{type.Name}Wrapper";
		}
	}
}