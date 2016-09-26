using System;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeGeneratorOptions : IGenerator
	{
		ITypeGeneratorOptions AsPublic();
		ITypeGeneratorOptions AsPartial();
		ITypeGeneratorOptions WithName(string name);
		ITypeGeneratorOptions WithNamingStrategy(ITypeNamingStrategy strategy);
		ITypeGeneratorOptions WithNoContract();
		ITypeGeneratorOptions WithNoImplementation();
		ITypeGeneratorOptions ExcludingMembersFrom<T>();
		ITypeGeneratorOptions ExcludingMembersFrom(Type type);
	}
}