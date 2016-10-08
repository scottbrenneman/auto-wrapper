using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using FluentAssertions;
using Microsoft.CSharp;
using Moq;
using GwtUnit.XUnit;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using AutoWrapper.Tests.TestClasses;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class ContractGeneratorTests : XUnitTestBase<ContractGeneratorTests.Thens>
    {
		[Fact]
		public void ShouldCompile_WhenGenerating()
		{
			Given.Type = typeof(SomeType);

			When(Generating, Compiling);

			Then.CompilerResults.Errors.HasErrors.Should().BeFalse();
			Then.CompilerResults.Errors.HasWarnings.Should().BeFalse();
		}

		[Fact]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.Type = typeof(SomeType);
			Given.AsPublicWasCalled = true;

			When(Generating, Compiling);

			Then.Contract.IsPublic.Should().BeTrue();
		}

		[Fact]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
			Given.Type = typeof(SomeType);
			Given.CustomNamingStrategy = CustomNamingStrategy();

			When(Generating, Compiling);

			Then.Contract.Name.Should().Be("CustomContractName");
		}

		private static IContractNamingStrategy CustomNamingStrategy()
		{
			var customNamingStrategy = new Mock<IContractNamingStrategy>();

			customNamingStrategy
				.Setup(s => s.ContractNameFor(It.IsAny<Type>()))
				.Returns("CustomContractName");

			return customNamingStrategy.Object;
		}

		[Fact]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions()
		{
			Given.Type = typeof(SomeType);

			When(Generating, Compiling);

			Then.Contract.Should().HaveMethod("Function1", new[] { typeof(int) });
			Then.Contract.Should().HaveMethod("Function2", new[] { typeof(bool), typeof(object) });
			Then.Contract.Should().HaveMethod("Function3", new[] { typeof(int), typeof(string) });
		}

		[Fact]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			Given.Type = typeof(SomeType);

			When(Generating, Compiling);

			Then.Contract.Should().HaveProperty<bool>("Property1");
			Then.Contract.Should().HaveProperty<object>("Property2");
		}

		[Fact]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludingMembersFrom()
		{
			Given.Type = typeof(SomeType);
			Given.Exclude = typeof(object);

			When(Generating, Compiling);

			Then.Contract.Should().NotHaveMethod("ToString", new Type[0]);
			Then.Contract.Should().NotHaveMethod("Equals", new[] { typeof(object) });
			Then.Contract.Should().NotHaveMethod("GetType", new Type[0]);
			Then.Contract.Should().NotHaveMethod("GetHashCode", new Type[0]);
		}

		private void Generating()
		{
			Then.Code = Then.Target.GenerateCode(Given.Type);
		}

		private void Compiling()
		{
			var provider = new CSharpCodeProvider();

			var referencedAssemblies =
				AppDomain.CurrentDomain.GetAssemblies()
					.Where(a => !a.IsDynamic)
					.Select(a => a.Location)
					.ToArray();

			var parameters = new CompilerParameters(referencedAssemblies) { GenerateInMemory = true };

			var code = $"namespace AutoWrapper.Tests.CodeGen {{ {Then.Code} }}";

			Then.CompilerResults = provider.CompileAssemblyFromSource(parameters, code);

			if (Then.CompilerResults.Errors.HasErrors == false)
				Then.Contract = Then.CompilerResults.CompiledAssembly.Types().Single(t => t.IsInterface);
		}

		protected override void Creating()
		{
			var options = new ContractGeneratorOptions();

			if (GivensDefined("AsPublicWasCalled"))
				options.WithPublic();
			
			if (GivensDefined("CustomNamingStrategy"))
				options.WithNamingStrategy(Given.CustomNamingStrategy);

			if (GivensDefined("Exclude"))
				options.ExcludeMembersFrom(Given.Exclude);

			Then.Target = new ContractGenerator(options);
		}

		public sealed class Thens
		{
			public ContractGenerator Target;
			public string Code;
			public CompilerResults CompilerResults;
			public Type Contract;
		}
    }
}