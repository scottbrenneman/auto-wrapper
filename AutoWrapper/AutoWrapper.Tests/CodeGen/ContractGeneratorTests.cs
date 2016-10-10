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

			Then.CodeTypeDeclaration.Members.Should().HaveCount(13);

			Then.CodeTypeDeclaration.BaseTypes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.Comments.Should().HaveCount(1);
			Then.CodeTypeDeclaration.CustomAttributes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.EndDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.StartDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.TypeParameters.Should().HaveCount(0);
			Then.CodeTypeDeclaration.UserData.Should().HaveCount(0);
		}

		[Fact]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.Type = typeof(SomeType);
			Given.AsPublicWasCalled = true;

			When(Generating);

			Then.CodeTypeDeclaration.TypeAttributes.Should().HaveFlag(TypeAttributes.Public);
		}

		[Fact]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
			Given.Type = typeof(SomeType);
			Given.CustomNamingStrategy = CustomNamingStrategy();

			When(Generating);

			Then.CodeTypeDeclaration.Name.Should().Be("CustomContractName");
		}


		[Theory,
		InlineData(0, "Equals", new[] { "System.Object" }),
		InlineData(1, "Function1", new[] { "System.Int32" }),
		InlineData(2, "Function2", new[] { "System.Boolean", "System.Object" }),
		InlineData(3, "Function3", new[] { "System.Int32", "System.String" }),
		InlineData(4, "Function4", new[] { "System.Int32", "System.String", "System.Object" }),
		InlineData(5, "GetHashCode", new string[0]),
		InlineData(6, "GetType", new string[0]),
		InlineData(7, "InheritedFunction", new string[0]),
		InlineData(8, "ToString", new string[0])
		]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions(int index, string name, string[] paramterTypes)
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			Then.Methods.Should().HaveCount(9);

			Then.Methods[index].Name.Should().Be(name);
			Then.Methods[index].Parameters.Should().HaveCount(paramterTypes.Length);

			for (var n = 0; n < paramterTypes.Length; n++)
			{
				Then.Methods[index].Parameters[n].Type.BaseType.Should().Be(paramterTypes[n]);
			}
		}

		[Theory,
		InlineData("Function1", 0, FieldDirection.In),
		InlineData("Function2", 0, FieldDirection.In),
		InlineData("Function3", 0, FieldDirection.In),
		InlineData("Function4", 0, FieldDirection.Out),
		InlineData("Function4", 1, FieldDirection.Ref),
		InlineData("Function4", 2, FieldDirection.In)]
		public void ShouldHaveDirectionalParameters_WhenGenerating_GivenMethod(string method, int parameter, FieldDirection direction)
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			var memberMethod = Then.Methods.First(x => x.Name == method);
			memberMethod.Should().NotBeNull();

			memberMethod.Parameters[parameter].Direction.Should().Be(direction);
		}

		[Fact]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			Then.Properties[0].Name.Should().Be("Property1");
			Then.Properties[0].Type.BaseType.Should().Be("System.Boolean");
			Then.Properties[1].Name.Should().Be("Property2");
			Then.Properties[1].Type.BaseType.Should().Be("System.Object");
		}

		[Theory,
		InlineData(0, "Function1"),
		InlineData(1, "Function2"),
		InlineData(2, "Function3"),
		InlineData(3, "Function4"),
		InlineData(4, "InheritedFunction")
		]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludedType(int index, string name)
		{
			Given.Type = typeof(SomeType);
			Given.Exclude = typeof(object);

			When(Generating);

			Then.Methods.Should().HaveCount(5);

			Then.Methods[index].Name.Should().Be(name);
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

		private static IContractNamingStrategy CustomNamingStrategy()
		{
			var customNamingStrategy = new Mock<IContractNamingStrategy>();

			customNamingStrategy
				.Setup(s => s.ContractNameFor(It.IsAny<Type>()))
				.Returns("CustomContractName");

			return customNamingStrategy.Object;
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