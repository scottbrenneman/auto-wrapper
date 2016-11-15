using System;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IContractGeneratorOptionsBuilder
	{
		IContractGeneratorOptionsBuilder WithPublic();
		IContractGeneratorOptionsBuilder WithPartial();
		IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn<TType>();
		IContractGeneratorOptionsBuilder ExcludeMembersDeclaredOn(Type type);
		IContractGeneratorOptions AsOptions { get; }
	}

	public interface IContractGeneratorOptions
    {
		TypeAttributes GetTypeAttributes();
		bool IsExcluded(MemberInfo member);
		bool UsePartial { get; }
		IContractGeneratorOptionsBuilder AsBuilder { get; }
	}
}