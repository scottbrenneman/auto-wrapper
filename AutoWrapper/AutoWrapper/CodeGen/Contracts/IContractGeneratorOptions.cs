using System;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGeneratorOptionsBuilder
	{
		IContractGeneratorOptionsBuilder WithPublic();
		IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn<TType>();
		IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn(Type type);
		IContractGeneratorOptions AsOptions { get; }
	}

	public interface IContractGeneratorOptions
    {
		TypeAttributes GetTypeAttributes();
		bool IsExcluded(MemberInfo member);
		IContractGeneratorOptionsBuilder AsBuilder { get; }
	}
}