using AutoWrapper.CodeGen;
using System;
using System.CodeDom;
using System.Reflection;

namespace AutoWrapper
{
	public static class AutoWrap
	{
		public static string Type<T>(string namespaceForWrappers)
			where T: class
		{
			var container = new WrappedTypeContainer()
				.Register<T>();

			return GenerateCode(namespaceForWrappers, container);
		}

		public static string TypesInAssemblyWith(Type type, string namespaceForWrappers)
		{
			return TypesInAssembly(Assembly.GetAssembly(type), namespaceForWrappers);
		}

		public static string TypesInAssembly(Assembly assembly, string namespaceForWrappers)
		{
			var container = new WrappedTypeContainer()
				.RegisterAssembly(assembly);

			return GenerateCode(namespaceForWrappers, container);
		}

		private static string GenerateCode(string namespaceForWrappers, IWrappedTypeContainer container)
		{
			var typeOptions = new TypeGeneratorOptions()
				.WithPartial()
				.WithPublic()
				.AsOptions;

			var contractOptions = new ContractGeneratorOptions()
				.ExcludeMembersDeclaredOn<object>()
				.AsOptions;

			var typeGenerator = new TypeGenerator(typeOptions, container);

			var contractGenerator = new ContractGenerator(contractOptions, container);

			var codeGenerator = new CodeGenerator();

			var ns = new CodeNamespace(namespaceForWrappers);
			ns.Imports.Add(new CodeNamespaceImport("System"));

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