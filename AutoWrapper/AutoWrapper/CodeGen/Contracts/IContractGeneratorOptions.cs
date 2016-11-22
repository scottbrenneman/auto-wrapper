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
		IContractGeneratorOptions Build();
	}

	public interface IContractGeneratorOptions
    {
		TypeAttributes GetTypeAttributes();
		bool IsExcluded(MemberInfo member);
		bool UsePartial { get; }
	}
}