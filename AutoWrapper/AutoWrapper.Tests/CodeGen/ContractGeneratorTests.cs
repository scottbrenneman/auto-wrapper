using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using Moq;
using GwtUnit.XUnit;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoWrapper.Tests.TestClasses;
using FluentAssertions;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class ContractGeneratorTests : XUnitTestBase<ContractGeneratorTests.Thens>
    {
		[Fact]
		public void ShouldCompile_WhenGenerating()
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			Then.CodeTypeDeclaration.ShouldBeEquivalentTo(new
			{
				Attributes = 20482,
				IsClass = false,
				IsEnum = false,
				IsInterface = true,
				IsPartial = false,
				IsStruct = false,
				LinePragma = (CodeLinePragma)null,
				Name = "ISomeTypeWrapper",
				TypeAttributes = TypeAttributes.Interface
			}, options => options.ExcludingMissingMembers());

			Then.CodeTypeDeclaration.Members.Should().HaveCount(12);

			Then.CodeTypeDeclaration.BaseTypes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.Comments.Should().HaveCount(0);
			Then.CodeTypeDeclaration.CustomAttributes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.EndDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.StartDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.TypeParameters.Should().HaveCount(0);
			Then.CodeTypeDeclaration.UserData.Should().HaveCount(0);
		}

		[Fact(Skip = "needs fixing")]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.Type = typeof(SomeType);
			Given.AsPublicWasCalled = true;

			When(Generating);

			//Then.CodeTypeDeclaration.IsPublic.Should().BeTrue();
		}

		[Fact(Skip = "needs fixing")]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
			Given.Type = typeof(SomeType);
			Given.CustomNamingStrategy = CustomNamingStrategy();

			When(Generating);

			//Then.CodeTypeDeclaration.Name.Should().Be("CustomContractName");
		}

		private static IContractNamingStrategy CustomNamingStrategy()
		{
			var customNamingStrategy = new Mock<IContractNamingStrategy>();

			customNamingStrategy
				.Setup(s => s.ContractNameFor(It.IsAny<Type>()))
				.Returns("CustomContractName");

			return customNamingStrategy.Object;
		}

		[Fact(Skip = "needs fixing")]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions()
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			//Then.Contract.Should().HaveMethod("Function1", new[] { typeof(int) });
			//Then.Contract.Should().HaveMethod("Function2", new[] { typeof(bool), typeof(object) });
			//Then.Contract.Should().HaveMethod("Function3", new[] { typeof(int), typeof(string) });
		}

		[Fact(Skip = "needs fixing")]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			//Then.Contract.Should().HaveProperty<bool>("Property1");
			//Then.Contract.Should().HaveProperty<object>("Property2");
		}

		[Fact(Skip = "needs fixing")]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludedType()
		{
			Given.Type = typeof(SomeType);
			Given.Exclude = typeof(object);

			When(Generating);

			//Then.Contract.Should().NotHaveMethod("ToString", new Type[0]);
			//Then.Contract.Should().NotHaveMethod("Equals", new[] { typeof(object) });
			//Then.Contract.Should().NotHaveMethod("GetType", new Type[0]);
			//Then.Contract.Should().NotHaveMethod("GetHashCode", new Type[0]);
		}

		protected override void Creating()
		{
			var options = new ContractGeneratorOptions();

			if (GivensDefined("AsPublicWasCalled"))
				options.WithPublic();
			
			if (GivensDefined("Exclude"))
				options.ExcludeMembersDeclaredOn(Given.Exclude);

			Then.Container = new WrappedTypeContainer(null, Given.CustomNamingStrategy);
			Then.Container.Register(Given.Type);
			Then.Target = new ContractGenerator(options, Then.Container);
		}

		private void Generating()
		{
			Then.CodeTypeDeclaration = Then.Target.GenerateDeclaration(Given.Type);

			Then.Methods = Then.CodeTypeDeclaration.Members
				.Cast<CodeTypeMember>()
				.Select(m => m as CodeMemberMethod)
				.Where(f => f != null)
				.OrderBy(f => f.Name)
				.ToList();

			Then.Properties = Then.CodeTypeDeclaration.Members
				.Cast<CodeTypeMember>()
				.Select(m => m as CodeMemberProperty)
				.Where(f => f != null)
				.ToList();

			Then.Fields = Then.CodeTypeDeclaration.Members
				.Cast<CodeTypeMember>()
				.Select(m => m as CodeMemberField)
				.Where(f => f != null)
				.ToList();
		}

		public sealed class Thens
		{
			public ContractGenerator Target;
			public CodeTypeDeclaration CodeTypeDeclaration;
			public WrappedTypeContainer Container;
			public List<CodeMemberMethod> Methods;
			public List<CodeMemberProperty> Properties;
			public List<CodeMemberField> Fields;
		}
    }
}