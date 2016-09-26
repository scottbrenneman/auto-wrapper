using AutoWrapper.CodeGen;
using FluentAssertions;
using Randal.Core.Testing.XUnit;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class DefaultContractNamingStrategyTests : XUnitTestBase<DefaultContractNamingStrategyTests.Thens>
	{
		[Fact]
		public void ShouldPrefixTypeWithI_WhenGeneratingContractName()
		{
			When(GeneratingContractName);

			Then.ContractName.Should().Be("ISomeType");
		}

		private void GeneratingContractName()
		{
			Then.ContractName = Then.Target.ContractNameFor(typeof(SomeType));
		}

		protected override void Creating()
		{
			Then.Target = new DefaultContractNamingStrategy();
		}

		public class Thens
		{
			public DefaultContractNamingStrategy Target;
			public string ContractName;
		}

		private class SomeType { }
	}
}