using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AutoWrapper.Tests.TestClasses
{
	[ExcludeFromCodeCoverage]
	public sealed class SomeType : SomeTypeBase, IDisposable
	{
		public void Function1(int x) { throw new NotImplementedException(); }

		public int Function2(bool? b, Tuple<string, int> o) { throw new NotImplementedException(); }

		public async Task<string> Function3(int x, string s) { throw new NotImplementedException(); }

		public string Function4(out int x, ref string s, object o) { throw new NotImplementedException(); }

		public SomeOtherType Function5(SomeOtherType sot) { throw new NotImplementedException(); }

		public bool Property1 { get; set; }

		public object Property2 { get; internal set; }

		public string this[int x] => string.Empty;

		private string NotSupportedProperty { get; }

		private void NotSupportedFunction()
		{
		}

		public void Dispose() { throw new NotImplementedException(); }
	}

	[ExcludeFromCodeCoverage]
	public class SomeTypeBase
	{
		public void InheritedFunction() { throw new NotImplementedException(); }
	}

	[ExcludeFromCodeCoverage]
	public sealed class SomeOtherType
	{ }
}