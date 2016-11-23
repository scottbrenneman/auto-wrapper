using FluentAssertions;
using GwtUnit.XUnit;
using System;
using System.Collections.Generic;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class TypeExtensionsTests : XUnitTestBase<TypeExtensionsTests.Thens>
	{
		[Theory,
		InlineData(typeof(object), "System.Object"),
		InlineData(typeof(void), "System.Void"),
		InlineData(typeof(int), "System.Int32"),
		InlineData(typeof(bool), "System.Boolean"),
		InlineData(typeof(string), "System.String"),
		InlineData(typeof(int?), "System.Int32?"),
		InlineData(typeof(IEnumerable<Tuple<int?, Tuple<string, bool?>>>), "System.Collections.Generic.IEnumerable<System.Tuple<System.Int32?, System.Tuple<System.String, System.Boolean?>>>")
		]
		public void ShouldHaveName_WhenGettingName_GivenType(Type givenType, string expectedName)
		{
			Given.Type = givenType;

			When(GettingTypeName);

			Then.ActualName.Should().Be(expectedName);
		}

		private void GettingTypeName()
		{
			Then.ActualName = ((Type)Given.Type).GetName();
		}

		protected override void Creating() { }

		public sealed class Thens
		{
			public string ActualName;
		}
	}
}