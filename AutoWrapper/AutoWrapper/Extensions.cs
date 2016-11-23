using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoWrapper
{
	internal static class TypeExtensions
	{
		public static bool IsAsync(this MethodInfo methodInfo) => methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>() != null;

		public static bool IsIndexer(this PropertyInfo propertyInfo) => propertyInfo.GetIndexParameters().Length > 0;

		public static bool IsByRef(this ParameterInfo parameter) => parameter.ParameterType.IsByRef;

		public static string GetName(this Type type)
		{
			if (type.IsGenericType == false)
				return type.FullName;

			var argTypes = type.GetGenericArguments()
				.Select(arg => arg.GetName())
				.ToArray();

			var genericType = type.GetGenericTypeDefinition();
			if (genericType == typeof(Nullable<>))
				return $"{argTypes[0]}?";

			var fn = genericType.FullName;

			return $"{fn.Substring(0, fn.IndexOf('`'))}<{string.Join(", ", argTypes)}>";
		}
	}

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