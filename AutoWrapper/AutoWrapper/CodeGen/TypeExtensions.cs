using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoWrapper.CodeGen
{
	internal static class TypeExtensions
	{
		public static CodeMemberMethod ToMemberMethod(this MethodInfo methodInfo, GenerateAs generateAs)
		{
			if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));
			if (methodInfo.IsPublic == false) throw new NotSupportedException("Non-public methods are not supported.");

			var attributes = MemberAttributes.Public;
			attributes |= MethodsToOverride.Contains(methodInfo.Name) ? MemberAttributes.Override : MemberAttributes.Final;

			var isAsync = generateAs == GenerateAs.Type && methodInfo.IsAsync();

			var memberMethod = new CodeMemberMethod
			{
				Attributes = attributes,
				Name = methodInfo.Name,
				ReturnType = new CodeTypeReference(isAsync ? $"async {methodInfo.ReturnType.GetName()}" : methodInfo.ReturnType.GetName())
			};

			foreach (var parameter in methodInfo.GetParameters())
			{
				memberMethod.Parameters.Add(parameter.ToParameterDeclaration());
			}

			return memberMethod;
		}

		public static bool IsAsync(this MethodInfo methodInfo)
		{
			return methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>() != null;
		}

		public static CodeParameterDeclarationExpression ToParameterDeclaration(this ParameterInfo parameter)
		{
			var type = parameter.ParameterType.IsByRef
				? parameter.ParameterType.GetElementType()
				: parameter.ParameterType;

			var direction = parameter.ParameterType.IsByRef
				? (parameter.IsOut ? FieldDirection.Out : FieldDirection.Ref)
				: FieldDirection.In;

			return new CodeParameterDeclarationExpression(type.GetName(), parameter.Name)
			{
				Direction = direction
			};
		}

		public static CodeMemberProperty ToMemberProperty(this PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
				throw new ArgumentNullException(nameof(propertyInfo));

			if (propertyInfo.GetAccessors().Any() == false)
				throw new NotSupportedException("Non-public properties are not supported.");

			var property = new CodeMemberProperty
			{
				Attributes = MemberAttributes.Final | MemberAttributes.Public,
				Name = propertyInfo.Name,
				Type = new CodeTypeReference(new CodeTypeParameter(propertyInfo.PropertyType.GetName())),
				HasGet = propertyInfo.CanRead && propertyInfo.GetMethod.IsPublic,
				HasSet = propertyInfo.CanWrite && propertyInfo.SetMethod.IsPublic
			};

			if (propertyInfo.IsIndexer())
			{
				foreach (var parameter in propertyInfo.GetIndexParameters())
				{
					property.Parameters.Add(parameter.ToParameterDeclaration());
				}
			}

			return property;
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
				.Select(arg => arg.GetName())
				.ToArray();

			var genericType = type.GetGenericTypeDefinition();
			if (genericType == typeof(Nullable<>))
				return $"{argTypes[0]}?";

			var fn = genericType.FullName;

			return $"{fn.Substring(0, fn.IndexOf('`'))}<{string.Join(", ", argTypes)}>";
		}

		public static readonly List<string> MethodsToOverride = new List<string> { "ToString", "GetHashCode", "Equals" };
	}
}