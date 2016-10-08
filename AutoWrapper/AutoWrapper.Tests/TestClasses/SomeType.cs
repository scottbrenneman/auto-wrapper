using System;
using System.Diagnostics.CodeAnalysis;

namespace AutoWrapper.Tests.TestClasses
{
	[ExcludeFromCodeCoverage]
	public sealed class SomeType : SomeTypeBase
	{
		public void Function1(int x) { throw new NotImplementedException(); }

		public int Function2(bool b, object o) { throw new NotImplementedException(); }

		public string Function3(int x, string s) { throw new NotImplementedException(); }

		public bool Property1 { get; set; }

		public object Property2 { get; }

		private string NotSupportedProperty { get; }

		private void NotSupportedFunction()
		{
		}
	}

	[ExcludeFromCodeCoverage]
	public class SomeTypeBase
	{
		public void InheritedFunction() { throw new NotImplementedException(); }
	}
}