using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public sealed class MemberGenerator : IMemberGenerator
	{
		public MemberGenerator(IWrappedTypeDictionary wrappedTypeDictionary)
		{
			_wrappedTypeDictionary = wrappedTypeDictionary;
		}

		public CodeMemberMethod GenerateMethodDeclaration(MethodInfo methodInfo, GenerateAs generateAs)
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
				ReturnType = new CodeTypeReference(isAsync ? $"async {GetName(methodInfo.ReturnType)}" : GetName(methodInfo.ReturnType))
			};

			foreach (var parameter in methodInfo.GetParameters())
			{
				memberMethod.Parameters.Add(GenerateParameterDeclaration(parameter));
			}

			return memberMethod;
		}

		public CodeMemberProperty GeneratePropertyDeclaration(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
				throw new ArgumentNullException(nameof(propertyInfo));

			if (propertyInfo.GetAccessors().Any() == false)
				throw new NotSupportedException("Non-public properties are not supported.");

			var property = new CodeMemberProperty
			{
				Attributes = MemberAttributes.Final | MemberAttributes.Public,
				Name = propertyInfo.Name,
				Type = new CodeTypeReference(new CodeTypeParameter(GetName(propertyInfo.PropertyType))),
				HasGet = propertyInfo.CanRead && propertyInfo.GetMethod.IsPublic,
				HasSet = propertyInfo.CanWrite && propertyInfo.SetMethod.IsPublic
			};

			if (propertyInfo.IsIndexer())
			{
				foreach (var parameter in propertyInfo.GetIndexParameters())
				{
					property.Parameters.Add(GenerateParameterDeclaration(parameter));
				}
			}

			return property;
		}

		private CodeParameterDeclarationExpression GenerateParameterDeclaration(ParameterInfo parameter)
		{
			var type = parameter.ParameterType.IsByRef
				? parameter.ParameterType.GetElementType()
				: parameter.ParameterType;

			var direction = parameter.ParameterType.IsByRef
				? (parameter.IsOut ? FieldDirection.Out : FieldDirection.Ref)
				: FieldDirection.In;

			return new CodeParameterDeclarationExpression(GetName(type), parameter.Name)
			{
				Direction = direction
			};
		}

		private static string GetName(Type type)
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

		private readonly IWrappedTypeDictionary _wrappedTypeDictionary;

		private static readonly List<string> MethodsToOverride = new List<string> { "ToString", "GetHashCode", "Equals" };
	}
}