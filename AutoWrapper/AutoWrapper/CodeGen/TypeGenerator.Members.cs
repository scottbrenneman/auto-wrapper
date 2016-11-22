using System;
using System.CodeDom;

namespace AutoWrapper.CodeGen
{
	public sealed partial class TypeGenerator : GeneratorBase
	{
		private static CodeTypeMember[] CreateCompositionMembers(Type type)
		{
			var members = new CodeTypeMember[2];

			members[0] = new CodeMemberField($"readonly {type}", WrappedFieldName) { Attributes = MemberAttributes.Private };

			var constructor = new CodeConstructor { Attributes = MemberAttributes.Public };

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(type, WrappedVariableName));

			constructor.Statements.Add(
				new CodeAssignStatement(
					WrappedField,
					new CodeArgumentReferenceExpression(WrappedVariableName))
			);

			members[1] = constructor;

			return members;
		}

		private CodeMemberMethod CreateConvertWrapperMethod(Type type)
		{
			var memberMethod = new CodeMemberMethod
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Static,
				Name = ConvertWrapperFunction,
				ReturnType = new CodeTypeReference(type)
			};

			memberMethod.Parameters.Add(new CodeParameterDeclarationExpression(WrappedTypeDictionary.GetContractNameFor(type), "wrapper"));

			memberMethod.Statements.Add(
				new CodeMethodReturnStatement(
					new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("wrapper"), WrappedPropertyName)));

			return memberMethod;
		}

		private CodeMemberMethod CreateConvertWrappedMethod(Type type)
		{
			var memberMethod = new CodeMemberMethod
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Static,
				Name = ConvertWrappedFunction,
				ReturnType = new CodeTypeReference(WrappedTypeDictionary.GetContractNameFor(type))
			};

			memberMethod.Parameters.Add(new CodeParameterDeclarationExpression(type, WrappedVariableName));

			memberMethod.Statements.Add(
				new CodeMethodReturnStatement(
					new CodeObjectCreateExpression(WrappedTypeDictionary.GetTypeNameFor(type), new CodeVariableReferenceExpression(WrappedVariableName))));

			return memberMethod;
		}

		private CodeMethodInvokeExpression InvokeConvertAllWrapper(CodeExpression array, string elementTypeContract)
		{
			return new CodeMethodInvokeExpression(
				new CodeTypeReferenceExpression(typeof(Array)),
				"ConvertAll",
				array,
				new CodeMethodReferenceExpression(
					new CodeTypeReferenceExpression(
						WrappedTypeDictionary.GetTypeNameFor(elementTypeContract)),
						ConvertWrapperFunction)
			);
		}

		private CodeMethodInvokeExpression InvokeConvertAllWrapped(CodeExpression array, string elementTypeContract)
		{
			return new CodeMethodInvokeExpression(
				new CodeTypeReferenceExpression(typeof(Array)),
				"ConvertAll",
				array,
				new CodeMethodReferenceExpression(
					new CodeTypeReferenceExpression(
						WrappedTypeDictionary.GetTypeNameFor(elementTypeContract)),
						ConvertWrappedFunction)
			);
		}

		private const string ConvertWrapperFunction = "ConvertWrapper", ConvertWrappedFunction = "ConvertWrapped";
	}
}