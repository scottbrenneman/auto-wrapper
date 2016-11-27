using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Reflection;

namespace AutoWrapper
{
	public static class AutoWrap
	{
		public static string Type(Type type, string namespaceForWrapper)
		{
			var container = new WrappedTypeContainer().Register(type);

			return FromContainer(container, namespaceForWrapper);
		}

		public static string Type<T>(string namespaceForWrapper) where T : class => Type(typeof(T), namespaceForWrapper);

		public static string Assembly(Assembly assembly, string namespaceForWrappers)
		{
			var container = new WrappedTypeContainer().RegisterAssembly(assembly);

			return FromContainer(container, namespaceForWrappers);
		}

		public static string AssemblyWithType(Type type, string namespaceForWrappers) => Assembly(type.Assembly, namespaceForWrappers);

		public static string AssemblyWithType<T>(string namespaceForWrappers) where T : class => AssemblyWithType(typeof(T), namespaceForWrappers);

		public static string FromContainer(IWrappedTypeContainer container, string namespaceForWrappers)
		{
			var typeOptions = new TypeGeneratorOptionsBuilder(TypeNamingStrategy)
				.WithPartial()
				.WithPublic()
				.Build();

			var contractOptions = new ContractGeneratorOptionsBuilder(ContractNamingStrategy)
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

		public static IContractNamingStrategy ContractNamingStrategy = new DefaultNamingStrategy();
		public static ITypeNamingStrategy TypeNamingStrategy = new DefaultNamingStrategy();
	}
}