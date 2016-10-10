using AutoWrapper.CodeGen.Contracts;
using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;

namespace AutoWrapper.CodeGen
{
	public class ContractGenerator : GeneratorBase
    {
	    private readonly IContractGeneratorOptions _contractGeneratorOptions;

	    public ContractGenerator(IWrappedTypeContainer wrapperTypeContainer) : this(null, wrapperTypeContainer) { }

		public ContractGenerator(IContractGeneratorOptions contractGeneratorOptions, IWrappedTypeContainer wrappedTypeContainer)
			: base(wrappedTypeContainer)
		{
			_contractGeneratorOptions = contractGeneratorOptions ?? new ContractGeneratorOptions();
		}

		public override CodeTypeDeclaration GenerateDeclaration(Type type)
		{
			ValidateTypeBeforeGeneration(type);

			var contract = new CodeTypeDeclaration(WrappedTypeContainer.GetContractNameFor(type))
			{
				TypeAttributes = _contractGeneratorOptions.GetTypeAttributes(),
				IsInterface = true
			};

			contract.Comments.Add(new CodeCommentStatement($"Interface for {WrappedTypeContainer.GetTypeNameFor(type)}"));

			var methods = type
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(m => m.IsSpecialName == false)
				.Where(m => _contractGeneratorOptions.IsExcluded(m) == false );

			foreach (var method in methods)
				contract.Members.Add(method.ToMemberMethod());

			var properties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => _contractGeneratorOptions.IsExcluded(p) == false);

			foreach (var property in properties)
				contract.Members.Add(property.ToMemberProperty());

			contract.Members.Add(CreateWrappedProperty(type, false));

			return contract;
		}
	}
}