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
		private readonly IMemberGenerator _memberGenerator;

	    public ContractGenerator(IWrappedTypeDictionary wrappedTypeDictionary) : this(null, wrappedTypeDictionary) { }

		public ContractGenerator(IContractGeneratorOptions contractGeneratorOptions, IWrappedTypeDictionary wrappedTypeDictionary)
			: base(wrappedTypeDictionary)
		{
			_contractGeneratorOptions = contractGeneratorOptions ?? new ContractGeneratorOptions();
			_memberGenerator = new MemberGenerator(wrappedTypeDictionary);
		}

		public override CodeTypeDeclaration GenerateDeclaration(Type type)
		{
			ValidateTypeBeforeGeneration(type);

			var contract = new CodeTypeDeclaration(WrappedTypeDictionary.GetContractNameFor(type))
			{
				TypeAttributes = _contractGeneratorOptions.GetTypeAttributes(),
				IsInterface = true,
				IsPartial = _contractGeneratorOptions.UsePartial
			};

			contract.Comments.Add(new CodeCommentStatement($"Interface for {WrappedTypeDictionary.GetTypeNameFor(type)}"));

			if(type.GetInterfaces().Contains(typeof(IDisposable)))
				contract.BaseTypes.Add("System.IDisposable");

			GenerateMethods(type, contract);

			GenerateProperties(type, contract);

			contract.Members.Add(CreateWrappedProperty(type, GenerateAs.Contract));

			return contract;
		}

	    private void GenerateProperties(IReflect type, CodeTypeDeclaration contract)
	    {
		    var properties = type
			    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
			    .Where(p => _contractGeneratorOptions.IsExcluded(p) == false);

		    foreach (var property in properties)
			    contract.Members.Add(_memberGenerator.GeneratePropertyDeclaration(property));
	    }

	    private void GenerateMethods(IReflect type, CodeTypeDeclaration contract)
	    {
		    var methods = type
			    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
			    .Where(m => m.IsSpecialName == false)
			    .Where(m => _contractGeneratorOptions.IsExcluded(m) == false && m.Name != "Dispose");

		    foreach (var method in methods)
			    contract.Members.Add(_memberGenerator.GenerateMethodDeclaration(method, GenerateAs.Contract));
	    }
    }
}