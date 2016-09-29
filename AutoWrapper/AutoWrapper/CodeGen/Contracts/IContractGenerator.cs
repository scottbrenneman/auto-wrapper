using System;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGenerator
	{
		IContractGeneratorOptions ContractFor<TType>();

        IContractGeneratorOptions ContractFor(Type type);
    }
}
