using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using FluentAssertions;
using Moq;
using GwtUnit.XUnit;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoWrapper.Tests.TestClasses;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class TypeGeneratorTests : XUnitTestBase<TypeGeneratorTests.Thens>
	{
		[Fact]
		public void ShouldHaveDeclaration_WhenGenerating()
		{
			When(Generating);

			Then.CodeTypeDeclaration.ShouldBeEquivalentTo(new
			{
				Attributes = 20482,
				IsClass = true,
				IsEnum = false,
				IsInterface = false,
				IsPartial = false,
				IsStruct = false,
				LinePragma = (CodeLinePragma)null,
				Name = "SomeTypeWrapper",
				TypeAttributes = TypeAttributes.AnsiClass
			}, options => options.ExcludingMissingMembers());

			Then.CodeTypeDeclaration.BaseTypes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.Comments.Should().HaveCount(0);
			Then.CodeTypeDeclaration.CustomAttributes.Should().HaveCount(0);
			Then.CodeTypeDeclaration.EndDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.Members.Should().HaveCount(12);
			Then.CodeTypeDeclaration.StartDirectives.Should().HaveCount(0);
			Then.CodeTypeDeclaration.TypeParameters.Should().HaveCount(0);
			Then.CodeTypeDeclaration.UserData.Should().HaveCount(0);
		}

		[Fact]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.AsPublicWasCalled = true;

			When(Generating);

			Then.CodeTypeDeclaration.TypeAttributes.Should().HaveFlag(TypeAttributes.Public);
		}

		[Fact]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
			Given.CustomNamingStrategy = CustomNamingStrategy();

			When(Generating);

			Then.CodeTypeDeclaration.Name.Should().Be("CustomTypeName");
		}

		[Theory,
		InlineData(0, ".ctor", new[] { "AutoWrapper.Tests.TestClasses.SomeType" }),
		InlineData(1, "Equals", new[] { "System.Object" }),
		InlineData(2, "Function1", new [] { "System.Int32" }),
		InlineData(3, "Function2", new[] { "System.Boolean", "System.Object" }),
		InlineData(4, "Function3", new[] { "System.Int32", "System.String" }),
		InlineData(5, "GetHashCode", new string[0]),
		InlineData(6, "GetType", new string[0]),
		InlineData(7, "InheritedFunction", new string[0]),
		InlineData(8, "ToString", new string[0])
		]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions(int index, string name, params string[] paramterTypes)
		{
			When(Generating);

			Then.Methods.Should().HaveCount(9);

			Then.Methods[index].Name.Should().Be(name);
			Then.Methods[index].Parameters.Should().HaveCount(paramterTypes.Length);

			for (var n = 0; n < paramterTypes.Length; n++)
			{	
				Then.Methods[index].Parameters[n].Type.BaseType.Should().Be(paramterTypes[n]);
			}
		}

		[Fact]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			When(Generating);

			Then.Properties.Should().HaveCount(2);

			Then.Properties[0].Name.Should().Be("Property1");
			Then.Properties[0].Type.BaseType.Should().Be("System.Boolean");
			Then.Properties[1].Name.Should().Be("Property2");
			Then.Properties[1].Type.BaseType.Should().Be("System.Object");
		}

		[Fact]
		public void ShouldComposeWrappedType_WhenGenerating()
		{
			When(Generating);

			Then.Fields.Should().HaveCount(1);

			Then.Fields[0].Name.Should().Be("_wrapped");
			Then.Fields[0].Type.BaseType.Should().Be("AutoWrapper.Tests.TestClasses.SomeType");
		}
		
		protected override void Creating()
		{
			var options = new TypeGeneratorOptions();

			if (GivensDefined("AsPublicWasCalled"))
				options.WithPublic();

			if (GivensDefined("CustomNamingStrategy"))
				options.WithNamingStrategy(Given.CustomNamingStrategy);

			Then.Target = new TypeGenerator(options.AsOptions);
		}

		private void Generating()
		{
			Then.CodeTypeDeclaration = Then.Target.GenerateDeclaration(typeof(SomeType));

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

		private static ITypeNamingStrategy CustomNamingStrategy()
		{
			var customNamingStrategy = new Mock<ITypeNamingStrategy>();

			customNamingStrategy
				.Setup(s => s.TypeNameFor(It.IsAny<Type>()))
				.Returns("CustomTypeName");

			return customNamingStrategy.Object;
		}

		public class Thens
		{
			public TypeGenerator Target;
			public string Code;
			public CodeTypeDeclaration CodeTypeDeclaration;
			public List<CodeMemberMethod> Methods;
			public List<CodeMemberProperty> Properties;
			public List<CodeMemberField> Fields;
		}
	}
}