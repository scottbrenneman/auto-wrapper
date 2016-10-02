using System;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGeneratorOptionsBuilder
	{
		IContractGeneratorOptionsBuilder WithPublic();
		IContractGeneratorOptionsBuilder WithNamingStrategy(IContractNamingStrategy strategy);
		IContractGeneratorOptions AsOptions { get; }
	}

	public interface IContractGeneratorOptions
    {
		string GetNameFor(Type type);
	    TypeAttributes GetTypeAttributes();
		IContractGeneratorOptionsBuilder AsBuilder { get; }
	}
}