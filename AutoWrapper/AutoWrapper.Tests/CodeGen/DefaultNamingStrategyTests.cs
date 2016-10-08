using AutoWrapper.CodeGen;
using AutoWrapper.Tests.TestClasses;
using FluentAssertions;
using GwtUnit.XUnit;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class DefaultNamingStrategyTests : XUnitTestBase<DefaultNamingStrategyTests.Thens>
	{
		[Fact]
		public void ShouldPrefixTypeWithI_WhenGeneratingContractName()
		{
			When(GeneratingContractName);

			Then.ContractName.Should().Be("ISomeType");
		}

		[Fact]
		public void ShouldPrefixTypeWithWrapped_WhenGeneratingTypeName()
		{
			When(GeneratingTypeName);

			Then.TypeName.Should().Be("WrappedSomeType");
		}

		private void GeneratingContractName()
		{
			Then.ContractName = Then.Target.ContractNameFor(typeof(SomeType));
		}

		private void GeneratingTypeName()
		{
			Then.TypeName = Then.Target.TypeNameFor(typeof(SomeType));
		}

		protected override void Creating()
		{
			Then.Target = new DefaultNamingStrategy();
		}

		public sealed class Thens
		{
			public DefaultNamingStrategy Target;
			public string ContractName;
			public string TypeName;
		}
	}
}