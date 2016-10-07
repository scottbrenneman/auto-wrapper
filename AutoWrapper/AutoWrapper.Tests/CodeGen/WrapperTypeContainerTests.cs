using System;
using AutoWrapper.CodeGen;
using GwtUnit.XUnit;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class WrapperTypeContainerTests : XUnitTestBase<WrapperTypeContainerTests.Thens>
	{
		[Fact]
		public void ShouldHaveRegisteredType_WhenRegistering_GivenSomeType()
		{
		}

		protected override void Creating()
		{
			Then.Target = new WrapperTypeContainer();
		}

		public sealed class Thens
		{
			public WrapperTypeContainer Target;
		}
	}
}
