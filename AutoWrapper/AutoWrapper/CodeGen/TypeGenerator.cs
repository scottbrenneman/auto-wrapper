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

			generatedType.Comments.Add(new CodeCommentStatement($"wrapper for {type.FullName} in {type.Assembly.FullName}"));

			generatedType.BaseTypes.Add(WrappedTypeDictionary.GetContractNameFor(type));

			generatedType.Members.AddRange(CompositionMembersFor(type));

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

		private static void BuildPropertySetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			if (property.IsIndexer())
			{
				memberProperty.SetStatements.Add(
					new CodeAssignStatement(
						new CodeIndexerExpression(
							WrappedField,
							memberProperty.Parameters.Cast<CodeParameterDeclarationExpression>()
								.Select(p => new CodeVariableReferenceExpression(p.Name))
								.ToArray<CodeExpression>()),

						new CodePropertySetValueReferenceExpression()
					)
				);

				return;
			}

			memberProperty.SetStatements.Add(
				new CodeAssignStatement(
					new CodePropertyReferenceExpression(
						WrappedField, memberProperty.Name),
					new CodePropertySetValueReferenceExpression())
			);
		}

		private static void BuildPropertyGetter(CodeMemberProperty memberProperty, PropertyInfo property)
		{
			if (property.IsIndexer())
			{
				memberProperty.GetStatements.Add(
					new CodeMethodReturnStatement(
						new CodeIndexerExpression(
							WrappedField,
							memberProperty.Parameters.Cast<CodeParameterDeclarationExpression>()
								.Select(p => new CodeVariableReferenceExpression(p.Name))
								.ToArray<CodeExpression>()))
				);

				return;
			}

			memberProperty.GetStatements.Add(
				new CodeMethodReturnStatement(
					new CodePropertyReferenceExpression(
						WrappedField,
						memberProperty.Name))
			);
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
						.Select(p => (CodeExpression) new CodeDirectionExpression(p.Direction, new CodeVariableReferenceExpression(p.Name)))
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

		private static CodeTypeMember[] CompositionMembersFor(Type type)
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
	}
}