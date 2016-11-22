using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoWrapper.CodeGen
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
}