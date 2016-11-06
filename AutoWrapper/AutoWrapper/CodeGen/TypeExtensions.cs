using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoWrapper.CodeGen
{
	internal static class TypeExtensions
	{
		public static bool IsAsync(this MethodInfo methodInfo)
		{
			return methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>() != null;
		}

		public static bool IsIndexer(this PropertyInfo propertyInfo)
		{
			return propertyInfo.GetIndexParameters().Length > 0;
		}

		public static string GetName(this Type type)
		{
			if (type.IsGenericType == false)
				return type.FullName;

			var argTypes = type.GetGenericArguments()
				.Select(arg => GetName(arg))
				.ToArray();

			var genericType = type.GetGenericTypeDefinition();
			if (genericType == typeof(Nullable<>))
				return $"{argTypes[0]}?";

			var fn = genericType.FullName;

			return $"{fn.Substring(0, fn.IndexOf('`'))}<{string.Join(", ", argTypes)}>";
		}
	}
}