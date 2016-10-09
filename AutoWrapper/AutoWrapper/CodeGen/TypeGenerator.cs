using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
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

			foreach (var property in properties)
			{
				var memberProperty = property.ToMemberProperty();

				if (memberProperty.HasGet)
				{
					memberProperty.GetStatements.Add(
						new CodeMethodReturnStatement(
							new CodePropertyReferenceExpression(
								new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
								memberProperty.Name))
					);
				}

				if (memberProperty.HasSet)
				{
					memberProperty.SetStatements.Add(
						new CodeAssignStatement(
							new CodePropertyReferenceExpression(
								new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"), memberProperty.Name),
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
						new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
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

		public string GenerateCode(Type type)
		{
			var generatedType = ((IGenerator)this).GenerateDeclaration(type);

			using (var provider = CodeDomProvider.CreateProvider("CSharp"))
			using (var writer = new StringWriter())
			{
				var options = new CodeGeneratorOptions { BracingStyle = "C" };

				provider.GenerateCodeFromType(generatedType, writer, options);

				return writer.ToString();
			}
		}

		private static CodeTypeMember[] CompositionMembersFor(Type type)
		{
			var members = new CodeTypeMember[2];

			members[0] = new CodeMemberField(type, "_wrapped") { Attributes = MemberAttributes.Private };

			var constructor = new CodeConstructor() { Attributes = MemberAttributes.Public };

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(type, "wrapped"));

			constructor.Statements.Add(
				new CodeAssignStatement(
					new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_wrapped"),
					new CodeArgumentReferenceExpression("wrapped"))
			);

			members[1] = constructor;

			return members;
		}
	}
}