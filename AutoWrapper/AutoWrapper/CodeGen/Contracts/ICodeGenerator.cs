using System.CodeDom;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ICodeGenerator
	{
		string GenerateCode(CodeTypeDeclaration declaration);
	}
}