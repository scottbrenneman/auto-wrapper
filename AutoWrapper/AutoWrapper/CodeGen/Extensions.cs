using System.CodeDom;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	internal static class CodeTypeReferenceExtensions
	{
		public static bool IsArray(this CodeTypeReference typeReference) => typeReference.ArrayElementType != null;
	}

	internal static class CodeAttributeDeclarationCollectionExtensions
	{
		public static void AddExcludeFromCodeCoverage(this CodeAttributeDeclarationCollection attributes)
		{
			attributes.Add(new CodeAttributeDeclaration("System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage"));
		}

		public static void AddGeneratedCode(this CodeAttributeDeclarationCollection attributes)
		{
			var tool = "AutoWrapper";

			var version = Assembly
				.GetAssembly(typeof(CodeAttributeDeclarationCollectionExtensions))
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
				.InformationalVersion;

			attributes.Add(new CodeAttributeDeclaration(
					"System.CodeDom.Compiler.GeneratedCode",
					new CodeAttributeArgument(new CodePrimitiveExpression(tool)),
					new CodeAttributeArgument(new CodePrimitiveExpression(version))
				)
			);
		}
	}
}