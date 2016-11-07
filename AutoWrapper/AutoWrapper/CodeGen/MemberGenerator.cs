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
		private readonly IWrappedTypeDictionary _wrappedTypeDictionary;

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

			var returnType = ReplaceRegisteredTypes(methodInfo.ReturnType);

			var memberMethod = new CodeMemberMethod
			{
				Attributes = attributes,
				Name = methodInfo.Name,
				ReturnType = new CodeTypeReference(isAsync ? $"async {returnType}" : returnType)
			};

			foreach (var parameter in methodInfo.GetParameters())
			{
				memberMethod.Parameters.Add(GenerateParameterDeclaration(parameter));
			}

			return memberMethod;
		}

		private string ReplaceRegisteredTypes(Type type)
		{
			if (type.IsArray)
			{
				var elementType = type.GetElementType();
				
				return _wrappedTypeDictionary.Registered(elementType)
					? $"{_wrappedTypeDictionary.GetContractNameFor(elementType)}[]"
					: type.GetName();
			}

			if (type.IsGenericType == false)
			{
				return _wrappedTypeDictionary.Registered(type)
					? _wrappedTypeDictionary.GetContractNameFor(type)
					: type.GetName();
			}

			var argTypes = type.GetGenericArguments()
				.Select(t => ReplaceRegisteredTypes(t))
				.ToArray();

			var genericType = type.GetGenericTypeDefinition();
			if (genericType == typeof(Nullable<>))
				return $"{argTypes[0]}?";

			var fn = genericType.FullName;

			return $"{fn.Substring(0, fn.IndexOf('`'))}<{string.Join(", ", argTypes)}>";
		}

		public CodeMemberProperty GeneratePropertyDeclaration(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
				throw new ArgumentNullException(nameof(propertyInfo));

			if (propertyInfo.GetAccessors().Any() == false)
				throw new NotSupportedException("Non-public properties are not supported.");

			var propertyType = ReplaceRegisteredTypes(propertyInfo.PropertyType);

			var property = new CodeMemberProperty
			{
				Attributes = MemberAttributes.Final | MemberAttributes.Public,
				Name = propertyInfo.Name,
				Type = new CodeTypeReference(new CodeTypeParameter(propertyType)),
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

			var paramType = ReplaceRegisteredTypes(type);

			return new CodeParameterDeclarationExpression(paramType, parameter.Name)
			{
				Direction = direction
			};
		}

		private static readonly List<string> MethodsToOverride = new List<string> { "ToString", "GetHashCode", "Equals" };
	}
}