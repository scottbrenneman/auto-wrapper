using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public sealed partial class TypeGenerator : GeneratorBase
	{
		private readonly ITypeGeneratorOptions _typeGeneratorOptions;
		private readonly MemberGenerator _memberGenerator;
		
		public TypeGenerator(IWrappedTypeDictionary wrappedTypeDictionary) : this(null, wrappedTypeDictionary) { }

		public TypeGenerator(ITypeGeneratorOptions typeGeneratorOptions, IWrappedTypeDictionary wrappedTypeDictionary)
			: base(wrappedTypeDictionary)
		{
			_typeGeneratorOptions = typeGeneratorOptions ?? new TypeGeneratorOptionsBuilder().Build();
			_memberGenerator = new MemberGenerator(wrappedTypeDictionary);
		}
		
		public override CodeTypeDeclaration GenerateDeclaration(Type type)
		{
			ValidateTypeBeforeGeneration(type);

			var generatedType = new CodeTypeDeclaration(WrappedTypeDictionary.GetTypeNameFor(type))
			{
				IsClass = true,
				TypeAttributes = _typeGeneratorOptions.GetTypeAttributes() | TypeAttributes.Sealed,
				IsPartial = _typeGeneratorOptions.UsePartial
			};

			generatedType.CustomAttributes.Add(new CodeAttributeDeclaration("System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage"));

			generatedType.Comments.Add(new CodeCommentStatement($"wrapper for {type.GetName()} in {type.Assembly.FullName}"));

			generatedType.BaseTypes.Add(WrappedTypeDictionary.GetContractNameFor(type));

			generatedType.Members.AddRange(CreateCompositionMembers(type));
			
			GenerateMethods(type, generatedType);

			GenerateProperties(type, generatedType);

			generatedType.Members.Add(CreateWrappedProperty(type, GenerateAs.Type));
			generatedType.Members.Add(CreateConvertWrapperMethod(type));
			generatedType.Members.Add(CreateConvertWrappedMethod(type));

			return generatedType;
		}
		
		private void GenerateProperties(IReflect type, CodeTypeDeclaration generatedType)
		{
			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (var property in properties)
			{
				var memberProperty = _memberGenerator.GeneratePropertyDeclaration(property);

				if (memberProperty.HasGet)
					BuildPropertyGetter(memberProperty, property);

				if (memberProperty.HasSet)
					BuildPropertySetter(memberProperty, property);

				generatedType.Members.Add(memberProperty);
			}
		}

		private void BuildPropertyGetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			if (property.IsIndexer())
			{
				CodeExpression indexerExpression = new CodeIndexerExpression(
					WrappedField,
					memberProperty.Parameters.Cast<CodeParameterDeclarationExpression>()
						.Select(p => new CodeVariableReferenceExpression(p.Name))
						.ToArray<CodeExpression>());

				if (IsRegistered(property.PropertyType))
					indexerExpression = new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(property.PropertyType), indexerExpression);

				memberProperty.GetStatements.Add(new CodeMethodReturnStatement(indexerExpression));

				return;
			}

			if (memberProperty.Type.IsArray() && IsRegistered(memberProperty.Type.ArrayElementType.BaseType))
			{
				var array = InvokeConvertAllWrapped(
					new CodePropertyReferenceExpression(WrappedField, memberProperty.Name),
					memberProperty.Type.ArrayElementType.BaseType
				);

				memberProperty.GetStatements.Add(new CodeMethodReturnStatement(array));

				return;
			}

			CodeExpression expression = new CodePropertyReferenceExpression(WrappedField, memberProperty.Name);

			if (IsRegistered(property.PropertyType))
				expression = new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(property.PropertyType), expression);

			memberProperty.GetStatements.Add(new CodeMethodReturnStatement(expression));
		}

		private void BuildPropertySetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			CodeExpression valueExpression = new CodePropertySetValueReferenceExpression();

			if (IsRegistered(property.PropertyType))
				valueExpression = new CodePropertyReferenceExpression(valueExpression, WrappedPropertyName);

			if (property.IsIndexer())
			{
				memberProperty.SetStatements.Add(
					new CodeAssignStatement(
						new CodeIndexerExpression(
							WrappedField,
							memberProperty.Parameters.Cast<CodeParameterDeclarationExpression>()
								.Select(p => new CodeVariableReferenceExpression(p.Name))
								.ToArray<CodeExpression>()),
						valueExpression
					)
				);

				return;
			}

			memberProperty.SetStatements.Add(
				new CodeAssignStatement(
					new CodePropertyReferenceExpression(
						WrappedField, memberProperty.Name),
					valueExpression)
			);
		}

		private void GenerateMethods(IReflect type, CodeTypeDeclaration generatedType)
		{
			var methods = type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false)
				.Where(m => m.Name != "GetType");

			foreach (var method in methods)
				generatedType.Members.Add(GenerateMethod(method));
		}

		private CodeMemberMethod GenerateMethod(MethodInfo method)
		{
			var memberMethod = _memberGenerator.GenerateMethodDeclaration(method);

			if (method.IsAsync())
				memberMethod.ReturnType.BaseType = "async " + memberMethod.ReturnType.BaseType;

			var targetVariable = method.IsAsync()
				? new CodeVariableReferenceExpression("await " + WrappedFieldName)
				: new CodeVariableReferenceExpression(WrappedFieldName);

			CodeExpression invokeExpression =
				new CodeMethodInvokeExpression(
					targetVariable,
					memberMethod.Name,
					memberMethod.Parameters.OfType<CodeParameterDeclarationExpression>()
						.Select(p =>
						{
							CodeExpression variableExpression = new CodeVariableReferenceExpression(p.Name);

							if (p.Type.IsArray() && IsRegistered(p.Type.ArrayElementType.BaseType))
								return InvokeConvertAllWrapper(variableExpression, p.Type.ArrayElementType.BaseType);

							if (IsRegistered(p.Type.BaseType))
								variableExpression = new CodePropertyReferenceExpression(variableExpression, WrappedPropertyName);

							return (CodeExpression) new CodeDirectionExpression(p.Direction, variableExpression);
						})
						.ToArray()
				);

			if (memberMethod.ReturnType.BaseType == "System.Void")
			{
				memberMethod.Statements.Add(invokeExpression);
			}
			else
			{
				if (IsRegistered(method.ReturnType))
				{
					invokeExpression = new CodeObjectCreateExpression(
						WrappedTypeDictionary.GetTypeNameFor(method.ReturnType),
						invokeExpression
					);
				}

				memberMethod.Statements.Add(new CodeMethodReturnStatement(invokeExpression));
			}

			return memberMethod;
		}
	}
}