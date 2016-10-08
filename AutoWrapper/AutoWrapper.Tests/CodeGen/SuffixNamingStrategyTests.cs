using AutoWrapper.CodeGen;
using FluentAssertions;
using GwtUnit.XUnit;
using Xunit;
using AutoWrapper.Tests.TestClasses;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class SuffixNamingStrategyTests : XUnitTestBase<SuffixNamingStrategyTests.Thens>
	{
		[Fact]
		public void ShouldPrefixTypeWithI_WhenGeneratingContractName()
		{
			When(GeneratingContractName);

			Then.ContractName.Should().Be("ISomeTypeWrapper");
		}

		[Fact]
		public void ShouldSuffixTypeWithWrapper_WhenGeneratingTypeName()
		{
			When(GeneratingTypeName);

			Then.TypeName.Should().Be("SomeTypeWrapper");
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
			Then.Target = new SuffixNamingStrategy();
		}

		public sealed class Thens
		{
			public SuffixNamingStrategy Target;
			public string ContractName;
			public string TypeName;
		}
	}
}