using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using FluentAssertions;
using Microsoft.CSharp;
using Moq;
using Randal.Core.Testing.XUnit;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class TypeGeneratorTests : XUnitTestBase<TypeGeneratorTests.Thens>
	{
		[Fact]
		public void ShouldCompile_WhenGenerating()
		{
			When(Generating, Compiling);

			Then.CompilerResults.Errors.HasErrors.Should().BeFalse();
			Then.CompilerResults.Errors.HasWarnings.Should().BeFalse();
		}

		[Fact]
		public void ShouldGenerateContract_WhenGenerating()
		{
			When(Generating, Compiling);

			Then.Contract.Should().NotBeNull();
		}

		[Fact]
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.AsPublicWasCalled = true;

			When(Generating, Compiling);

			Then.GeneratedType.IsPublic.Should().BeTrue();
		}

		[Fact]
		public void ShouldUseName_WhenGenerating_GivenName()
		{
			Given.Name = "SomeRenamedWrappedType";

			When(Generating, Compiling);

			Then.GeneratedType.Name.Should().Be("SomeRenamedWrappedType");
		}

		[Fact]
		public void ShouldUseNamingStrategy_WhenGenerating_GivenNamingStrategy()
		{
			Given.CustomNamingStrategy = CustomNamingStrategy();

			When(Generating, Compiling);

			Then.GeneratedType.Name.Should().Be("CustomTypeName");
		}

		private static ITypeNamingStrategy CustomNamingStrategy()
		{
			var customNamingStrategy = new Mock<ITypeNamingStrategy>();

			customNamingStrategy
				.Setup(s => s.TypeNameFor(It.IsAny<Type>()))
				.Returns("CustomTypeName");

			return customNamingStrategy.Object;
		}

		[Fact]
		public void ShouldDeclareFunctions_WhenGenerating_GivenTypeWithFunctions()
		{
			When(Generating, Compiling);

			Then.GeneratedType.Should().HaveMethod("Function1", new Type[0]);
			Then.GeneratedType.Should().HaveMethod("Function2", new[] { typeof(int) });
			Then.GeneratedType.Should().HaveMethod("Function3", new[] { typeof(int), typeof(string) });
		}

		[Fact]
		public void ShouldDeclareProperties_WhenGenerating_GivenTypeWithProperties()
		{
			When(Generating, Compiling);

			Then.GeneratedType.Should().HaveProperty<bool>("Property1");
			Then.GeneratedType.Should().HaveProperty<object>("Property2");
		}

		[Fact]
		public void ShouldExcludeMembers_WhenGenerating_GivenExcludingMembersFrom()
		{
			Given.Exclude = typeof(object);

			When(Generating, Compiling);

			Then.GeneratedType.Should().NotHaveMethod("ToString", new Type[0]);
			Then.GeneratedType.Should().NotHaveMethod("Equals", new[] { typeof(object) });
			Then.GeneratedType.Should().NotHaveMethod("GetType", new Type[0]);
			Then.GeneratedType.Should().NotHaveMethod("GetHashCode", new Type[0]);
		}

		[Fact]
		public void ShouldComposeWrappedType_WhenGenerating()
		{
			When(Generating, Compiling);

			Then.WrappedField.Should().NotBeNull();
			Then.WrappedField.FieldType.Should().Be<SomeType>();

			Then.Constructor.Should().NotBeNull();
			Then.Constructor.GetParameters().First().ParameterType.Should().Be<SomeType>();
		}

		private void Generating()
		{
			var options = Then.Target.WrapperFor<SomeType>();

			if (GivensDefined("AsPublicWasCalled"))
				options.AsPublic();

			if (GivensDefined("Name"))
				options.WithName(Given.Name);

			if (GivensDefined("CustomNamingStrategy"))
				options.WithNamingStrategy(Given.CustomNamingStrategy);

			if (GivensDefined("Exclude"))
				options.ExcludingMembersFrom(Given.Exclude);

			Then.Code = options.GenerateCode();
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
			{
				Then.Contract = Then.CompilerResults.CompiledAssembly.Types().FirstOrDefault(t => t.IsInterface);
				Then.GeneratedType = Then.CompilerResults.CompiledAssembly.Types().First(t => t.IsClass);
				Then.WrappedField = Then.GeneratedType.GetField("_wrapped", BindingFlags.NonPublic | BindingFlags.Instance);
				Then.Constructor = Then.GeneratedType.GetConstructor(new[] { typeof(SomeType) });
			}
		}

		protected override void Creating()
		{
			Then.Target = new TypeGenerator();
		}

		public class Thens
		{
			public TypeGenerator Target;
			public string Code;
			public CompilerResults CompilerResults;
			public Type Contract;
			public Type GeneratedType;
			public FieldInfo WrappedField;
			public ConstructorInfo Constructor;
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