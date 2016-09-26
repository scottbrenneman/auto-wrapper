using AutoWrapper.CodeGen;
using FluentAssertions;
using Randal.Core.Testing.XUnit;
using System;
using System.CodeDom;
using System.Reflection;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public class TypeExtensionsTests : XUnitTestBase<TypeExtensionsTests.Thens>
	{
		#region MemberMethod
		[Fact]
		public void ShouldSetName_WhenCreatingMemberMethod_GivenMethodInfo()
		{
			Given.MethodInfo1 = typeof(SomeType).GetMethod("Function1");
			Given.MethodInfo2 = typeof(SomeType).GetMethod("Function2");

			When(CreatingMemberMethod);

			Then.MemberMethod1.Name.Should().Be("Function1");
			Then.MemberMethod2.Name.Should().Be("Function2");
		}

		[Fact]
		public void ShouldSetReturnType_WhenCreatingMemberMethod_GivenMethodInfo()
		{
			Given.MethodInfo1 = typeof(SomeType).GetMethod("Function1");
			Given.MethodInfo2 = typeof(SomeType).GetMethod("Function2");

			When(CreatingMemberMethod);

			Then.MemberMethod1.ReturnType.BaseType.Should().Be("System.Void");
			Then.MemberMethod2.ReturnType.BaseType.Should().Be("System.String");
		}

		[Fact]
		public void ShouldSetParameters_WhenCreatingMemberMethod_GivenMethodInfo()
		{
			Given.MethodInfo1 = typeof(SomeType).GetMethod("Function1");
			Given.MethodInfo2 = typeof(SomeType).GetMethod("Function2");

			When(CreatingMemberMethod);

			Then.MemberMethod1.Parameters[0].Type.BaseType.Should().Be("System.Int32");
			Then.MemberMethod1.Parameters[0].Name.Should().Be("x");

			Then.MemberMethod2.Parameters[0].Type.BaseType.Should().Be("System.Boolean");
			Then.MemberMethod2.Parameters[0].Name.Should().Be("b");
			Then.MemberMethod2.Parameters[1].Type.BaseType.Should().Be("System.Object");
			Then.MemberMethod2.Parameters[1].Name.Should().Be("o");
		}

		[Fact]
		public void ShouldBePublic_WhenCreatingMemberMethod_GivenMethodInfo()
		{
			Given.MethodInfo1 = typeof(SomeType).GetMethod("Function1");
			Given.MethodInfo2 = typeof(SomeType).GetMethod("Function2");

			When(CreatingMemberMethod);

			Then.MemberMethod1.Attributes.Should().HaveFlag(MemberAttributes.Public);
			Then.MemberMethod2.Attributes.Should().HaveFlag(MemberAttributes.Public);
		}

		[Fact]
		public void ShouldThrow_WhenCreatingMemberMethod_GivenNonPublicMethodInfo()
		{
			Given.MethodInfo1 = typeof(SomeType).GetMethod("NotSupportedFunction", BindingFlags.NonPublic | BindingFlags.Instance);

			WhenLastActionDeferred(CreatingMemberMethod);

			ThenLastAction.ShouldThrow<NotSupportedException>();
		}

		private void CreatingMemberMethod()
		{
			Func<MethodInfo, CodeMemberMethod> func = m => m.ToMemberMethod();

			Then.MemberMethod1 = func(Given.MethodInfo1);
			Then.MemberMethod2 = func(Given.MethodInfo2);
		}
		#endregion

		#region MemberProperty
		[Fact]
		public void ShouldSetName_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Name.Should().Be("Property1");
			Then.MemberProperty2.Name.Should().Be("Property2");
		}

		[Fact]
		public void ShouldSetType_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Type.BaseType.Should().Be("System.Int32");
			Then.MemberProperty2.Type.BaseType.Should().Be("System.Object");
		}

		[Fact]
		public void ShouldBePublic_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Attributes.Should().HaveFlag(MemberAttributes.Public);
			Then.MemberProperty2.Attributes.Should().HaveFlag(MemberAttributes.Public);
		}

		[Fact]
		public void ShouldThrow_WhenCreatingMemberProperty_GivenNonPublicPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("NotSupportedProperty", BindingFlags.NonPublic | BindingFlags.Instance);

			WhenLastActionDeferred(CreatingMemberProperty);

			ThenLastAction.ShouldThrow<NotSupportedException>();
		}

		[Fact]
		public void ShouldDeclareGettersSetters_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");

			When(CreatingMemberProperty);

			Then.MemberProperty1.HasGet.Should().BeTrue();
			Then.MemberProperty1.HasSet.Should().BeFalse();

			Then.MemberProperty2.HasGet.Should().BeTrue();
			Then.MemberProperty2.HasSet.Should().BeTrue();
		}

		private void CreatingMemberProperty()
		{
			Func<PropertyInfo, CodeMemberProperty> func = p => p.ToMemberProperty();

			Then.MemberProperty1 = func(Given.PropertyInfo1);
			Then.MemberProperty2 = func(Given.PropertyInfo2);
		}
		#endregion

		protected override void Creating() { }

		public class Thens
		{
			public CodeMemberMethod MemberMethod1;
			public CodeMemberMethod MemberMethod2;

			public CodeMemberProperty MemberProperty1;
			public CodeMemberProperty MemberProperty2;
		}

		private class SomeType
		{
			public void Function1(int x) { throw new NotImplementedException(); }
			public string Function2(bool b, object o) { throw new NotImplementedException(); }
			protected void NotSupportedFunction() { throw new NotImplementedException(); }
			public int Property1 { get; }
			public object Property2 { get; set; }
			protected object NotSupportedProperty { get; set; }
		}
	}
}