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
	}
}