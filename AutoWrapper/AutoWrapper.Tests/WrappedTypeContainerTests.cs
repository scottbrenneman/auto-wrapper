using System.DirectoryServices;
using AutoWrapper.Tests.TestClasses;
using FluentAssertions;
using GwtUnit.XUnit;
using Xunit;

namespace AutoWrapper.Tests
{
	public sealed class WrappedTypeContainerTests : XUnitTestBase<WrappedTypeContainerTests.Thens>
	{
		[Fact]
		public void ShouldHaveRegisteredType_WhenRegistering_GivenSomeType()
		{
			Given.RegisterType = typeof(SomeType);

			When(Registering);

			Then.Target.RegisteredTypes.Should().HaveCount(1);
		}

		[Fact]
		public void ShouldHaveRegisteredTypes_WhenRegisteringAssembly_GivenDirectoryEntry()
		{
			Given.RegisterType = typeof(DirectoryEntry);

			When(RegisteringAssembly);

			Then.Target.RegisteredTypes.Should().HaveCount(99);
		}

		[Fact]
		public void ShouldHaveRegisteredTypes_WhenRegisteringAssemblyAndUnregisteringType_GivenDirectoryEntry()
		{
			Given.RegisterType = typeof(DirectoryEntry);
			Given.UnregisterType = typeof(SearchResult);

			When(RegisteringAssembly, Unregistering);

			Then.Target.RegisteredTypes.Should().HaveCount(98);
		}

		[Fact]
		public void ShouldHaveNoTypes_WhenRegisteringAndUnregisteringType_GivenDirectoryEntry()
		{
			When(Registering<DirectoryEntry>, Unregistering<DirectoryEntry>);

			Then.Target.RegisteredTypes.Should().HaveCount(0);
		}

		protected override void Creating()
		{
			Then.Target = new WrappedTypeContainer();
		}

		private void Registering()
		{
			Then.Target.Register(Given.RegisterType);
		}

		private void Unregistering()
		{
			Then.Target.Unregister(Given.UnregisterType);
		}

		private void RegisteringAssembly()
		{
			Then.Target.RegisterAssemblyWithType(Given.RegisterType);
		}

		private void Registering<T>()
			where T : class
		{
			Then.Target.Register<T>();
		}

		private void Unregistering<T>()
			where T : class
		{
			Then.Target.Unregister<T>();
		}

		public sealed class Thens
		{
			public WrappedTypeContainer Target;
		}
	}
}
