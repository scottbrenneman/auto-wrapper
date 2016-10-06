using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
    public class ContractGenerator : IGenerator
    {
	    private readonly IContractGeneratorOptions _contractGeneratorOptions;

	    public ContractGenerator() : this(null) { }

		public ContractGenerator(IContractGeneratorOptions contractGeneratorOptions)
		{
			_contractGeneratorOptions = contractGeneratorOptions ?? new ContractGeneratorOptions();
		}

		public CodeTypeDeclaration GenerateDeclaration(Type type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			var name = _contractGeneratorOptions.GetNameFor(type);

			var contract = new CodeTypeDeclaration(name)
			{
				TypeAttributes = _contractGeneratorOptions.GetTypeAttributes(),
				IsInterface = true
			};

			var methods = type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false);
				

			foreach (var method in methods)
				contract.Members.Add(method.ToMemberMethod());

			var properties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (var property in properties)
				contract.Members.Add(property.ToMemberProperty());

			contract.Members.Add(
				new CodeMemberProperty()
				{
					Name = "Wrapped",
					HasGet = true,
					Type = new CodeTypeReference(type),
					Attributes = MemberAttributes.Public | MemberAttributes.Final
				}
			);

			return contract;
		}

		public string GenerateCode(Type type)
		{
			var contract = GenerateDeclaration(type);

			using (var provider = CodeDomProvider.CreateProvider("CSharp"))
			using (var writer = new StringWriter())
			{
				provider.GenerateCodeFromType(contract, writer, new CodeGeneratorOptions());

				return writer.ToString();
			}
		}
	}
}