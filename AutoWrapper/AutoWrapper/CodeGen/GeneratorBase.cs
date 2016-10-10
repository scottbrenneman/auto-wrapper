using System;
using System.CodeDom;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public abstract class GeneratorBase : IGenerator
	{
		protected GeneratorBase(IWrappedTypeContainer wrappedTypeContainer)
		{
			WrappedTypeContainer = wrappedTypeContainer;
		}

		protected void ValidateTypeBeforeGeneration(Type type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (WrappedTypeContainer.Registered(type) == false)
				throw new InvalidOperationException($"Type '{type.FullName}' must be registered with an IWrappedTypeContainer before a declaration can be generated.");
		}

		public abstract CodeTypeDeclaration GenerateDeclaration(Type type);

		protected CodeMemberProperty CreateWrappedProperty(Type type, bool withBody)
		{
			var property = new CodeMemberProperty()
			{
				Name = WrappedPropertyName,
				HasGet = true,
				Type = new CodeTypeReference(type),
				Attributes = MemberAttributes.Public | MemberAttributes.Final
			};

			if (withBody)
			{
				property.GetStatements.Add(new CodeMethodReturnStatement(WrappedField));
			}

			return property;
		}

		protected readonly IWrappedTypeContainer WrappedTypeContainer;

		protected const string WrappedVariableName = "wrapped", WrappedFieldName = "_wrapped", WrappedPropertyName = "Wrapped";


		protected static readonly CodeThisReferenceExpression This = new CodeThisReferenceExpression();
		protected static readonly CodeFieldReferenceExpression WrappedField = new CodeFieldReferenceExpression(This, WrappedFieldName);
	}
}