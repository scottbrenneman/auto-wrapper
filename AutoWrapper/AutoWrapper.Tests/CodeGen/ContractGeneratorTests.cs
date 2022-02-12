﻿using AutoWrapper.CodeGen;
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

			Then.CodeTypeDeclaration.Should().BeEquivalentTo(new
			{
				Attributes = (MemberAttributes) 20482,
				IsClass = false,
				IsEnum = false,
				IsInterface = true,
				IsPartial = false,
				IsStruct = false,
				LinePragma = (CodeLinePragma)null,
				Name = "ISomeTypeWrapper",
				TypeAttributes = TypeAttributes.Interface
			}, options => options.ExcludingMissingMembers());

			Then.CodeTypeDeclaration.Members.Count.Should().Be(15);
			Then.CodeTypeDeclaration.BaseTypes.Count.Should().Be(1);
			Then.CodeTypeDeclaration.BaseTypes[0].BaseType.Should().Be("System.IDisposable");
			
			Then.CodeTypeDeclaration.Comments.Count.Should().Be(1);
			Then.CodeTypeDeclaration.CustomAttributes.Count.Should().Be(1);
			Then.CodeTypeDeclaration.EndDirectives.Count.Should().Be(0);
			Then.CodeTypeDeclaration.StartDirectives.Count.Should().Be(0);
			Then.CodeTypeDeclaration.TypeParameters.Count.Should().Be(0);
			Then.CodeTypeDeclaration.UserData.Count.Should().Be(0);
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
		InlineData(0, "Equals", "System.Boolean", new[] { "System.Object" }),
		InlineData(1, "Function1", "System.Void", new[] { "System.Int32" }),
		InlineData(2, "Function2", "System.Int32", new[] { "System.Boolean?", "System.Tuple<System.String, System.Int32>" }),
		InlineData(3, "Function3", "System.Threading.Tasks.Task<System.String>", new[] { "System.Int32", "System.String" }),
		InlineData(4, "Function4", "System.String", new[] { "System.Int32", "System.String", "System.Object" }),
		InlineData(5, "Function5", "AutoWrapper.Tests.TestClasses.SomeOtherType", new[] { "AutoWrapper.Tests.TestClasses.SomeOtherType" }),
		InlineData(6, "GetHashCode", "System.Int32", new string[0]),
		InlineData(7, "GetType", "System.Type", new string[0]),
		InlineData(8, "InheritedFunction", "System.Void", new string[0]),
		InlineData(9, "ToString", "System.String", new string[0])
		]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions(int index, string name, string returnType, string[] parameterTypes)
		{
			Given.Type = typeof(SomeType);

			When(Generating);

			Then.Methods.Should().HaveCount(10);

			Then.Methods[index].Name.Should().Be(name);
			Then.Methods[index].ReturnType.BaseType.Should().Be(returnType);
			Then.Methods[index].Parameters.Count.Should().Be(parameterTypes.Length);

			for (var n = 0; n < parameterTypes.Length; n++)
			{
				Then.Methods[index].Parameters[n].Type.BaseType.Should().Be(parameterTypes[n]);
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
		InlineData(4, "Function5"),
		InlineData(5, "InheritedFunction")
		]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludedType(int index, string name)
		{
			Given.Type = typeof(SomeType);
			Given.Exclude = typeof(object);

			When(Generating);

			Then.Methods.Should().HaveCount(6);

			Then.Methods[index].Name.Should().Be(name);
		}

		protected override void Creating()
		{
			var options = new ContractGeneratorOptionsBuilder();

			if (GivensDefined("AsPublicWasCalled"))
				options.WithPublic();
			
			if (GivensDefined("Exclude"))
				options.ExcludeMembersDeclaredOn(Given.Exclude);

			Then.Container = new WrappedTypeContainer(null, Given.CustomNamingStrategy);
			Then.Container.Register(Given.Type);
			Then.Target = new ContractGenerator(options.Build(), Then.Container);
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