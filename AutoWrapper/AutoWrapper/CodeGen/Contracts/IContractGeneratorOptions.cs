using System;

namespace AutoWrapper.CodeGen.Contracts
{
    public interface IContractGeneratorOptions : IGenerator
    {
		IContractGeneratorOptions AsPublic();
		IContractGeneratorOptions WithName(string name);
		IContractGeneratorOptions WithNamingStrategy(IContractNamingStrategy strategy);
		IContractGeneratorOptions ExcludingMembersFrom<T>();
		IContractGeneratorOptions ExcludingMembersFrom(Type type);
	}
}