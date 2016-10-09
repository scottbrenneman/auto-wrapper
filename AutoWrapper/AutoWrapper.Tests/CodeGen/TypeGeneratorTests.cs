using AutoWrapper.CodeGen;
using AutoWrapper.CodeGen.Contracts;
using FluentAssertions;
using Microsoft.CSharp;
using Moq;
using GwtUnit.XUnit;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using AutoWrapper.Tests.TestClasses;
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
		public void ShouldGenerateAsPublic_WhenGenerating_GivenAsPublic()
		{
			Given.AsPublicWasCalled = true;

			When(Generating, Compiling);

			Then.GeneratedType.IsPublic.Should().BeTrue();
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

			Then.GeneratedType.Should().HaveMethod("Function1", new[] { typeof(int) });
			Then.GeneratedType.Should().HaveMethod("Function2", new[] { typeof(bool), typeof(object) });
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
			Then.Code = Then.Target.GenerateCode(typeof(SomeType));
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
			{
				Then.GeneratedType = Then.CompilerResults.CompiledAssembly.Types().First(t => t.IsClass);
				Then.WrappedField = Then.GeneratedType.GetField("_wrapped", BindingFlags.NonPublic | BindingFlags.Instance);
				Then.Constructor = Then.GeneratedType.GetConstructor(new[] { typeof(SomeType) });
			}
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

		public class Thens
		{
			public TypeGenerator Target;
			public string Code;
			public CompilerResults CompilerResults;
			public Type GeneratedType;
			public FieldInfo WrappedField;
			public ConstructorInfo Constructor;
		}
	}
}