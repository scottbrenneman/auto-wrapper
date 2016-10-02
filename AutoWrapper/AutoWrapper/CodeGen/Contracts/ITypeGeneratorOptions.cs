using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeGeneratorOptionsBuilder
	{
		ITypeGeneratorOptionsBuilder AsPublic();
		ITypeGeneratorOptionsBuilder AsPartial();
		ITypeGeneratorOptionsBuilder WithName(string name);
		ITypeGeneratorOptionsBuilder WithNamingStrategy(ITypeNamingStrategy strategy);
		ITypeGeneratorOptionsBuilder WithNamingStrategy(IContractNamingStrategy strategy);
		ITypeGeneratorOptionsBuilder WithNoContract();
		ITypeGeneratorOptionsBuilder WithNoImplementation();
		ITypeGeneratorOptionsBuilder ExcludingMembersFrom<T>();
		ITypeGeneratorOptionsBuilder ExcludingMembersFrom(Type type);
		ITypeGeneratorOptions AsOptions { get; }
	}

	public interface ITypeGeneratorOptions : IEnumerable<Type>
	{
		string GetTypeNameFor(Type type);
		string GetContractNameFor(Type type);
		TypeAttributes GetTypeAttributes();
		ITypeGeneratorOptionsBuilder AsBuilder { get; }
	}
}