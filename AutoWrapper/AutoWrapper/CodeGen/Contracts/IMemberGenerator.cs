using System.CodeDom;
using System.Reflection;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface IMemberGenerator
	{
		CodeMemberMethod GenerateMethodDeclaration(MethodInfo method);

		CodeMemberProperty GeneratePropertyDeclaration(PropertyInfo property);
	}
}