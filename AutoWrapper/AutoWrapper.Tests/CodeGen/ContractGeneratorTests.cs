using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using FluentAssertions;
using Microsoft.CSharp;
using Moq;
using Randal.Core.Testing.XUnit;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class ContractGeneratorTests : XUnitTestBase<ContractGeneratorTests.Thens>
    {
		[Fact]
		public void ShouldCompile_WhenGenerating()
		{
			When(Generating, Compiling);

			Then.CompilerResults.Errors.HasErrors.Should().BeFalse();
			Then.CompilerResults.Errors.HasWarnings.Should().BeFalse();
		}

		[Fact]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.AsPublicWasCalled = true;

			When(Generating, Compiling);

			Then.Contract.IsPublic.Should().BeTrue();
		}

		[Fact]
		public void ShouldUseName_WhenGenerating_GivenName()
		{
			Given.Name = "ISomeRenamedType";

			When(Generating, Compiling);

			Then.Contract.Name.Should().Be("ISomeRenamedType");
		}

		[Fact]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
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
			When(Generating, Compiling);

			Then.Contract.Should().HaveMethod("Function1", new Type[0]);
			Then.Contract.Should().HaveMethod("Function2", new[] { typeof(int) });
			Then.Contract.Should().HaveMethod("Function3", new[] { typeof(int), typeof(string) });
		}

		[Fact]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			When(Generating, Compiling);

			Then.Contract.Should().HaveProperty<bool>("Property1");
			Then.Contract.Should().HaveProperty<object>("Property2");
		}

		[Fact]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludingMembersFrom()
		{
			Given.Exclude = typeof(object);

			When(Generating, Compiling);

			Then.Contract.Should().NotHaveMethod("ToString", new Type[0]);
			Then.Contract.Should().NotHaveMethod("Equals", new[] { typeof(object) });
			Then.Contract.Should().NotHaveMethod("GetType", new Type[0]);
			Then.Contract.Should().NotHaveMethod("GetHashCode", new Type[0]);
		}

		private void Generating()
		{
			var options = Then.Target.ContractFor<SomeType>();

			if (GivensDefined("AsPublicWasCalled"))
				options.AsPublic();

			if (GivensDefined("Name"))
				options.WithName(Given.Name);

			if (GivensDefined("CustomNamingStrategy"))
				options.WithNamingStrategy(Given.CustomNamingStrategy);

			if (GivensDefined("Exclude"))
				options.ExcludingMembersFrom(Given.Exclude);

			Then.Code = options.GenerateCode(typeof(SomeType));
		}

		private void Compiling()
		{
			var provider = new CSharpCodeProvider();
			var parameters = new CompilerParameters
			{
				GenerateInMemory = true
			};

			var code = $"namespace AutoWrapper.Tests.CodeGen {{ {Then.Code} }}";

			Then.CompilerResults = provider.CompileAssemblyFromSource(parameters, code);

			if (Then.CompilerResults.Errors.HasErrors == false)
				Then.Contract = Then.CompilerResults.CompiledAssembly.Types().Single(t => t.IsInterface);
		}

		protected override void Creating()
		{
			Then.Target = new ContractGenerator();
		}

		public class Thens
		{
			public ContractGenerator Target;
			public string Code;
			public CompilerResults CompilerResults;
			public Type Contract;
		}

		private class SomeType
		{
			public void Function1() { throw new NotImplementedException(); }
			public int Function2(int x) { throw new NotImplementedException(); }
			public string Function3(int x, string s) { throw new NotImplementedException(); }
			public bool Property1 { get; set; }
			public object Property2 { get; }
		}
    }
}