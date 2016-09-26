namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGenerator
	{
		IContractGeneratorOptions ContractFor<TType>();
	}
}
