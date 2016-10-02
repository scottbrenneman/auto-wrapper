using System;
using System.CodeDom;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IGenerator
	{
		CodeTypeDeclaration GenerateDeclaration(Type type);

		string GenerateCode(Type type);
	}
}