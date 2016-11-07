using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public class TypeGenerator : GeneratorBase
	{
		private readonly ITypeGeneratorOptions _typeGeneratorOptions;
		private readonly IMemberGenerator _memberGenerator;
		
		public TypeGenerator(IWrappedTypeDictionary wrappedTypeDictionary) : this(null, wrappedTypeDictionary) { }

		public TypeGenerator(ITypeGeneratorOptions typeGeneratorOptions, IWrappedTypeDictionary wrappedTypeDictionary)
			: base(wrappedTypeDictionary)
		{
			_typeGeneratorOptions = typeGeneratorOptions ?? new TypeGeneratorOptions();
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

			generatedType.Comments.Add(new CodeCommentStatement($"wrapper for {type.GetName()} in {type.Assembly.FullName}"));

			generatedType.BaseTypes.Add(WrappedTypeDictionary.GetContractNameFor(type));

			generatedType.Members.AddRange(CompositionMembers(type));

			generatedType.Members.Add(GenerateConvertWrapperMethod(type));
			generatedType.Members.Add(GenerateConvertWrappedMethod(type));

			GenerateMethods(type, generatedType);

			GenerateProperties(type, generatedType);

			generatedType.Members.Add(CreateWrappedProperty(type, GenerateAs.Type));

			return generatedType;
		}
		
		private void GenerateProperties(IReflect type, CodeTypeDeclaration generatedType)
		{
			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (var property in properties)
			{
				var memberProperty = _memberGenerator.GeneratePropertyDeclaration(property);

				if (memberProperty.HasGet)
				{
					BuildPropertyGetter(memberProperty, property);
				}

				if (memberProperty.HasSet)
				{
					BuildPropertySetter(memberProperty, property);
				}

				generatedType.Members.Add(memberProperty);
			}
		}

		private void BuildPropertySetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			CodeExpression valueExpression = new CodePropertySetValueReferenceExpression();

			if (WrappedTypeDictionary.Registered(property.PropertyType))
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

		private void BuildPropertyGetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			if (property.IsIndexer())
			{
				CodeExpression indexerExpression = new CodeIndexerExpression(
					WrappedField,
					memberProperty.Parameters.Cast<CodeParameterDeclarationExpression>()
						.Select(p => new CodeVariableReferenceExpression(p.Name))
						.ToArray<CodeExpression>());

				if (WrappedTypeDictionary.Registered(property.PropertyType))
					indexerExpression = new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(property.PropertyType), indexerExpression);

				memberProperty.GetStatements.Add(new CodeMethodReturnStatement(indexerExpression));

				return;
			}

			CodeExpression expression = new CodePropertyReferenceExpression(WrappedField, memberProperty.Name);

			if (memberProperty.Type.ArrayElementType != null && WrappedTypeDictionary.Registered(memberProperty.Type.ArrayElementType.BaseType))
			{
				expression =
					new CodeMethodInvokeExpression(
						new CodeTypeReferenceExpression(typeof(Array)),
						"ConvertAll",
						expression,
						new CodeMethodReferenceExpression(
							new CodeTypeReferenceExpression(WrappedTypeDictionary.GetTypeNameFor(memberProperty.Type.ArrayElementType.BaseType)), "ConvertWrapped"));
			}

			if (WrappedTypeDictionary.Registered(property.PropertyType))
				expression = new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(property.PropertyType), expression);

			memberProperty.GetStatements.Add(new CodeMethodReturnStatement(expression));
		}

		private void GenerateMethods(IReflect type, CodeTypeDeclaration generatedType)
		{
			var methods = type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false);

			foreach (var method in methods.Where(m => m.Name != "GetType"))
			{
				var memberMethod = GenerateMethod(method);

				generatedType.Members.Add(memberMethod);
			}
		}

		private CodeMemberMethod GenerateMethod(MethodInfo method)
		{
			var memberMethod = _memberGenerator.GenerateMethodDeclaration(method, GenerateAs.Type);

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

							if (p.Type.ArrayElementType != null && WrappedTypeDictionary.Registered(p.Type.ArrayElementType.BaseType))
							{
								return new CodeMethodInvokeExpression(
									new CodeTypeReferenceExpression(typeof(Array)),
									"ConvertAll",
									variableExpression,
									new CodeMethodReferenceExpression(
										new CodeTypeReferenceExpression(WrappedTypeDictionary.GetTypeNameFor(p.Type.ArrayElementType.BaseType)), "ConvertWrapper"));
							}

							if (WrappedTypeDictionary.Registered(p.Type.BaseType))
								variableExpression = new CodePropertyReferenceExpression(variableExpression, WrappedPropertyName);

							return (CodeExpression) new CodeDirectionExpression(p.Direction, variableExpression);
						})
						.ToArray()
				);

			if (memberMethod.ReturnType.BaseType == "System.Void")
				memberMethod.Statements.Add(invokeExpression);
			else
			{
				if (WrappedTypeDictionary.Registered(method.ReturnType))
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

		private static CodeTypeMember[] CompositionMembers(Type type)
		{
			var members = new CodeTypeMember[2];

			members[0] = new CodeMemberField($"readonly {type}", WrappedFieldName) { Attributes = MemberAttributes.Private };

			var constructor = new CodeConstructor() { Attributes = MemberAttributes.Public };

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(type, WrappedVariableName));

			constructor.Statements.Add(
				new CodeAssignStatement(
					WrappedField,
					new CodeArgumentReferenceExpression(WrappedVariableName))
			);

			members[1] = constructor;

			return members;
		}

		private CodeMemberMethod GenerateConvertWrapperMethod(Type type)
		{
			var memberMethod = new CodeMemberMethod
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Static,
				Name = "ConvertWrapper",
				ReturnType = new CodeTypeReference(type)
			};

			memberMethod.Parameters.Add(new CodeParameterDeclarationExpression(WrappedTypeDictionary.GetContractNameFor(type), "wrapper"));

			memberMethod.Statements.Add(
				new CodeMethodReturnStatement(
					new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("wrapper"), WrappedPropertyName)));

			return memberMethod;
		}

		private CodeMemberMethod GenerateConvertWrappedMethod(Type type)
		{
			var memberMethod = new CodeMemberMethod
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Static,
				Name = "ConvertWrapped",
				ReturnType = new CodeTypeReference(WrappedTypeDictionary.GetContractNameFor(type))
			};

			memberMethod.Parameters.Add(new CodeParameterDeclarationExpression(type, "wrapped"));

			memberMethod.Statements.Add(
				new CodeMethodReturnStatement(
					new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(type), new CodeVariableReferenceExpression("wrapped"))));

			return memberMethod;
		}
	}
}