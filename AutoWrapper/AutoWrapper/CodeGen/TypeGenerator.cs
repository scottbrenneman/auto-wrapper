using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public class TypeGenerator : IGenerator
	{
		private readonly ITypeGeneratorOptions _typeGeneratorOptions;

		public TypeGenerator(ITypeGeneratorOptions typeGeneratorOptions)
		{
			_typeGeneratorOptions = typeGeneratorOptions;
		}
		
		public CodeTypeDeclaration GenerateDeclaration(Type type)
		{
			var name = _typeGeneratorOptions.GetNameFor(type);

			var generatedType = new CodeTypeDeclaration(name)
			{
				IsClass = true,
				TypeAttributes = _typeGeneratorOptions.GetTypeAttributes(),
				IsPartial = _typeGeneratorOptions.UsePartial
			};
			
			generatedType.Members.AddRange(CompositionMembersFor(type));

			GenerateMethods(type, generatedType);

			GenerateProperties(type, generatedType);

			return generatedType;
		}

		private static void GenerateProperties(IReflect type, CodeTypeDeclaration generatedType)
		{
			var properties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			var wrappedField = new CodeFieldReferenceExpression(This, WrappedFieldName);

			foreach (var property in properties)
			{
				var memberProperty = property.ToMemberProperty();

				if (memberProperty.HasGet)
				{
					memberProperty.GetStatements.Add(
						new CodeMethodReturnStatement(
							new CodePropertyReferenceExpression(
								wrappedField,
								memberProperty.Name))
					);
				}

				if (memberProperty.HasSet)
				{
					memberProperty.SetStatements.Add(
						new CodeAssignStatement(
							new CodePropertyReferenceExpression(
								wrappedField, memberProperty.Name),
							new CodePropertySetValueReferenceExpression())
					);
				}

				generatedType.Members.Add(memberProperty);
			}
		}

		private static void GenerateMethods(IReflect type, CodeTypeDeclaration generatedType)
		{
			var methods = type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false);

			foreach (var method in methods)
			{
				var memberMethod = method.ToMemberMethod();

				var invokeExpression =
					new CodeMethodInvokeExpression(
						new CodeFieldReferenceExpression(This, WrappedFieldName),
						memberMethod.Name,
						memberMethod.Parameters.OfType<CodeParameterDeclarationExpression>()
							.Select(p => (CodeExpression) new CodeVariableReferenceExpression(p.Name))
							.ToArray()
					);

				if (memberMethod.ReturnType.BaseType == "System.Void")
					memberMethod.Statements.Add(invokeExpression);
				else
					memberMethod.Statements.Add(new CodeMethodReturnStatement(invokeExpression));

				generatedType.Members.Add(memberMethod);
			}
		}

		private static CodeTypeMember[] CompositionMembersFor(Type type)
		{
			var members = new CodeTypeMember[2];

			members[0] = new CodeMemberField($"readonly {type}", WrappedFieldName) { Attributes = MemberAttributes.Private };

			var constructor = new CodeConstructor() { Attributes = MemberAttributes.Public };

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(type, WrappedVariableName));

			constructor.Statements.Add(
				new CodeAssignStatement(
					new CodeFieldReferenceExpression(This, WrappedFieldName),
					new CodeArgumentReferenceExpression(WrappedVariableName))
			);

			members[1] = constructor;

			return members;
		}

		private static readonly CodeThisReferenceExpression This = new CodeThisReferenceExpression();

		private const string WrappedVariableName = "wrapped", WrappedFieldName = "_wrapped";
	}
}