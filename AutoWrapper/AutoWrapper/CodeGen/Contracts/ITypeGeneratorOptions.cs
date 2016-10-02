using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeGeneratorOptionsBuilder
	{
		ITypeGeneratorOptionsBuilder WithPublic();
		ITypeGeneratorOptionsBuilder WithPartial();
		ITypeGeneratorOptionsBuilder WithNamingStrategy(ITypeNamingStrategy strategy);
		ITypeGeneratorOptionsBuilder WithNoContract();
		ITypeGeneratorOptionsBuilder WithNoImplementation();
		ITypeGeneratorOptions AsOptions { get; }
	}

	public interface ITypeGeneratorOptions
	{
		string GetNameFor(Type type);
		TypeAttributes GetTypeAttributes();
		ITypeGeneratorOptionsBuilder AsBuilder { get; }
	}
}