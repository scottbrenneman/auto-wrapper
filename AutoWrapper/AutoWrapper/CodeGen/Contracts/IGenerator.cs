using System.CodeDom;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IGenerator
	{
		CodeTypeDeclaration GenerateDeclaration();

		string GenerateCode();
	}
}