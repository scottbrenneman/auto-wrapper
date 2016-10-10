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

		protected readonly IWrappedTypeContainer WrappedTypeContainer;
	}
}