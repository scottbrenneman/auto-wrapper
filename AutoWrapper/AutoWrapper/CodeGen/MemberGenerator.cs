using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	internal sealed class MemberGenerator
	{
		private readonly IWrappedTypeDictionary _wrappedTypeDictionary;

		public MemberGenerator(IWrappedTypeDictionary wrappedTypeDictionary)
		{
			_wrappedTypeDictionary = wrappedTypeDictionary;
		}

		public CodeMemberMethod GenerateMethodDeclaration(MethodInfo methodInfo)
		{
			if (methodInfo == null) throw new ArgumentNullException(nameof(methodInfo));
			if (methodInfo.IsPublic == false) throw new NotSupportedException("Non-public methods are not supported.");

			var attributes = MemberAttributes.Public;

			attributes |= MethodsToOverride.Contains(methodInfo.Name) ? MemberAttributes.Override : MemberAttributes.Final;

			var returnType = GenerateTypeReference(methodInfo.ReturnType);

			var memberMethod = new CodeMemberMethod
			{
				Attributes = attributes,
				Name = methodInfo.Name,
				ReturnType = returnType
			};

			foreach (var parameter in methodInfo.GetParameters())
				memberMethod.Parameters.Add(GenerateParameterDeclaration(parameter));

			return memberMethod;
		}

		public CodeMemberProperty GeneratePropertyDeclaration(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));
			if (propertyInfo.GetAccessors().Any() == false) throw new NotSupportedException("Non-public properties are not supported.");

			var property = new CodeMemberProperty
			{
				Attributes = MemberAttributes.Final | MemberAttributes.Public,
				Name = propertyInfo.Name,
				Type = GenerateTypeReference(propertyInfo.PropertyType),
				HasGet = propertyInfo.CanRead && propertyInfo.GetMethod.IsPublic,
				HasSet = propertyInfo.CanWrite && propertyInfo.SetMethod.IsPublic
			};

			if (propertyInfo.IsIndexer())
			{
				foreach (var parameter in propertyInfo.GetIndexParameters())
					property.Parameters.Add(GenerateParameterDeclaration(parameter));
			}

			return property;
		}

		private CodeParameterDeclarationExpression GenerateParameterDeclaration(ParameterInfo parameter)
		{
			var type = parameter.IsByRef()
				? parameter.ParameterType.GetElementType()
				: parameter.ParameterType;

			var direction = parameter.IsByRef()
				? (parameter.IsOut ? FieldDirection.Out : FieldDirection.Ref)
				: FieldDirection.In;

			var paramType = GenerateTypeReference(type);

			return new CodeParameterDeclarationExpression(paramType, parameter.Name) { Direction = direction };
		}

		private CodeTypeReference GenerateTypeReference(Type type)
		{
			if (type.IsArray)
			{
				var elementType = type.GetElementType();

				var elementTypeReference = _wrappedTypeDictionary.Registered(elementType)
					? new CodeTypeReference(_wrappedTypeDictionary.GetContractNameFor(elementType))
					: new CodeTypeReference(elementType.GetName());

				return new CodeTypeReference(elementTypeReference, type.GetArrayRank());
			}

			if (type.IsGenericType == false)
			{
				var typeName = _wrappedTypeDictionary.Registered(type)
					? _wrappedTypeDictionary.GetContractNameFor(type)
					: type.GetName();

				return new CodeTypeReference(typeName);
			}

			return new CodeTypeReference(type.GetName());
		}

		private static readonly List<string> MethodsToOverride = new List<string> { "ToString", "GetHashCode", "Equals" };
	}
}