using System;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractNamingStrategy
	{
		string ContractNameFor(Type type);
	}
}