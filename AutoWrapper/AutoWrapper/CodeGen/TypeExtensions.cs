using System;
using System.CodeDom;
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

			var memberMethod = new CodeMemberMethod
			{
				Attributes = MemberAttributes.Public,
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
			if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));
			if (propertyInfo.GetAccessors().Any() == false) throw new NotSupportedException("Non-public properties are not supported.");

			return new CodeMemberProperty
			{
				Attributes = MemberAttributes.Public,
				Name = propertyInfo.Name,
				Type = new CodeTypeReference(propertyInfo.PropertyType),
				HasGet = propertyInfo.CanRead,
				HasSet = propertyInfo.CanWrite
			};
		}
	}
}