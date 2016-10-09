using AutoWrapper.CodeGen;
using System;
using System.Reflection;
using System.Text;

namespace AutoWrapper
{
	public static class AutoWrap
	{
		public static string Type<T>()
		{
			throw new NotImplementedException();
		}

		public static string TypesInAssemblyWith(Type type)
		{
			return TypesInAssembly(Assembly.GetAssembly(type));
		}

		public static string TypesInAssembly(Assembly assembly)
		{
			var container = new WrappedTypeContainer();
			container.RegisterAssembly(assembly);

			var typeOptions = new TypeGeneratorOptions()
				.WithPartial()
				.WithPublic()
				.AsOptions;

			var contractOptions = new ContractGeneratorOptions()
				.ExcludeMembersDeclaredOn<object>()
				.AsOptions;

			var typeGenerator = new TypeGenerator(typeOptions);

			var contractGenerator = new ContractGenerator(contractOptions);

			var codeGenerator = new CodeGenerator();

			var code = new StringBuilder();

			foreach (var type in container.RegisteredTypes)
			{
				code.AppendLine(
					codeGenerator.GenerateCode(
						contractGenerator.GenerateDeclaration(type)
					)
				);
			}

			foreach (var type in container.RegisteredTypes)
			{ 
				code.AppendLine(
					codeGenerator.GenerateCode(
						typeGenerator.GenerateDeclaration(type)
					)
				);
			}

			return code.ToString();
		}
	}
}