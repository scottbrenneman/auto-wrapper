using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeGeneratorOptionsBuilder
	{
		ITypeGeneratorOptionsBuilder WithPublic();
		ITypeGeneratorOptionsBuilder WithPartial();
		ITypeGeneratorOptions Build();
	}

	public interface ITypeGeneratorOptions
	{
		TypeAttributes GetTypeAttributes();
		bool UsePartial { get; }
	}
}