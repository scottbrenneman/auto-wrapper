using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	internal static class TypeExtensions
	{
		public static CodeMemberMethod ToMemberMethod(this MethodInfo methodInfo)
		{
			if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));
			if (methodInfo.IsPublic == false) throw new NotSupportedException("Non-public methods are not supported.");

			var attributes = MemberAttributes.Public;
			attributes |= MethodsToOverride.Contains(methodInfo.Name) ? MemberAttributes.Override : MemberAttributes.Final;

			var memberMethod = new CodeMemberMethod
			{
				Attributes = attributes,
				Name = methodInfo.Name,
				ReturnType = new CodeTypeReference(methodInfo.ReturnType)
			};

			foreach (var parameter in methodInfo.GetParameters())
			{
				memberMethod.Parameters.Add(parameter.ToParameterDeclaration());
			}

			return memberMethod;
		}

		public static CodeParameterDeclarationExpression ToParameterDeclaration(this ParameterInfo parameter)
		{
			var type = parameter.ParameterType.IsByRef
				? parameter.ParameterType.GetElementType()
				: parameter.ParameterType;

			var direction = parameter.ParameterType.IsByRef
				? (parameter.IsOut ? FieldDirection.Out : FieldDirection.Ref)
				: FieldDirection.In;

			return new CodeParameterDeclarationExpression(type.FullName, parameter.Name)
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
				Type = new CodeTypeReference(propertyInfo.PropertyType),
				HasGet = propertyInfo.CanRead,
				HasSet = propertyInfo.CanWrite
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

		public static readonly List<string> MethodsToOverride = new List<string> { "ToString", "GetHashCode", "Equals" };
	}
}