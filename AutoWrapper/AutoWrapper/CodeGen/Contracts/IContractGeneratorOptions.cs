using System;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGeneratorOptionsBuilder
	{
		IContractGeneratorOptionsBuilder WithPublic();
		IContractGeneratorOptionsBuilder WithNamingStrategy(IContractNamingStrategy strategy);
		IContractGeneratorOptionsBuilder ExcludeMembersFrom(Type type);
		IContractGeneratorOptions AsOptions { get; }
	}

	public interface IContractGeneratorOptions
    {
		TypeAttributes GetTypeAttributes();
		string GetNameFor(Type type);
		bool IsExcluded(MemberInfo member);
		IContractGeneratorOptionsBuilder AsBuilder { get; }
	}
}