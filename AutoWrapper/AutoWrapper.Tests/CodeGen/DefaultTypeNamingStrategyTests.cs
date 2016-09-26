using AutoWrapper.CodeGen;
using FluentAssertions;
using Randal.Core.Testing.XUnit;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class DefaultTypeNamingStrategyTests : XUnitTestBase<DefaultTypeNamingStrategyTests.Thens>
	{
		[Fact]
		public void ShouldPrefixTypeWithWrapped_WhenGeneratingTypeName()
		{
			When(GeneratingContractName);

			Then.TypeName.Should().Be("WrappedSomeType");
		}

		private void GeneratingContractName()
		{
			Then.TypeName = Then.Target.TypeNameFor(typeof(SomeType));
		}

		protected override void Creating()
		{
			Then.Target = new DefaultTypeNamingStrategy();
		}

		public class Thens
		{
			public DefaultTypeNamingStrategy Target;
			public string TypeName;
		}

		private class SomeType { }
	}
}