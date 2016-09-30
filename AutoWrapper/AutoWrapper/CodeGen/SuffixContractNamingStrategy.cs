using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class SuffixContractNamingStrategy : IContractNamingStrategy
	{
		public string ContractNameFor(Type type)
		{
			return $"I{type.Name}Wrapper";
		}
	}
}