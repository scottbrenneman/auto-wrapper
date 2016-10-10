using System;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeGeneratorOptionsBuilder
	{
		ITypeGeneratorOptionsBuilder WithPublic();
		ITypeGeneratorOptionsBuilder WithPartial();
		ITypeGeneratorOptionsBuilder WithNoImplementation();
		ITypeGeneratorOptions AsOptions { get; }
	}

	public interface ITypeGeneratorOptions
	{
		TypeAttributes GetTypeAttributes();
		bool UsePartial { get; }
		ITypeGeneratorOptionsBuilder AsBuilder { get; }
	}
}