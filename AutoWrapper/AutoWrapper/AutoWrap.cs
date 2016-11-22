using AutoWrapper.CodeGen;
using System.CodeDom;

namespace AutoWrapper
{
	public static class AutoWrap
	{
		public static string GenerateCode(string namespaceForWrappers, IWrappedTypeContainer container)
		{
			var typeOptions = new TypeGeneratorOptionsBuilder()
				.WithPartial()
				.WithPublic()
				.Build();

			var contractOptions = new ContractGeneratorOptionsBuilder()
				.WithPartial()
				.WithPublic()
				.ExcludeMembersDeclaredOn<object>()
				.Build();

			var typeGenerator = new TypeGenerator(typeOptions, container);

			var contractGenerator = new ContractGenerator(contractOptions, container);

			var codeGenerator = new CodeGenerator();

			var ns = new CodeNamespace(namespaceForWrappers);

			foreach (var type in container.RegisteredTypes)
			{
				ns.Types.Add(
					contractGenerator.GenerateDeclaration(type)
				);
			}

			foreach (var type in container.RegisteredTypes)
			{
				ns.Types.Add(
					typeGenerator.GenerateDeclaration(type)
				);
			}

			var targetUnit = new CodeCompileUnit();
			targetUnit.Namespaces.Add(ns);

			return codeGenerator.GenerateCode(targetUnit);
		}
	}
}