using AutoWrapper.CodeGen;
using AutoWrapper.Tests.TestClasses;
using FluentAssertions;
using GwtUnit.XUnit;
using Moq;
using System;
using System.CodeDom;
using System.Reflection;
using Xunit;

namespace AutoWrapper.Tests.CodeGen
{
	public sealed class MemberGeneratorTests : XUnitTestBase<MemberGeneratorTests.Thens>
	{
		#region MemberMethod
		[Theory,
		InlineData("Function1"),
		InlineData("Function2"),
		InlineData("Function3")]
		public void ShouldSetName_WhenCreatingMemberMethod_GivenMethodInfo(string name)
		{
			Given.MethodInfo = typeof(SomeType).GetMethod(name);

			When(CreatingMemberMethod);

			Then.MemberMethod.Name.Should().Be(name);
		}

		[Fact]
		public void ShouldSetParameters_WhenCreatingMemberMethod_GivenMethodInfoForFunction1()
		{
			Given.MethodInfo = typeof(SomeType).GetMethod("Function1");
			Given.MethodInfo2 = typeof(SomeType).GetMethod("Function2");

			When(CreatingMemberMethod);

			Then.MemberMethod.Parameters[0].Type.BaseType.Should().Be("System.Int32");
			Then.MemberMethod.Parameters[0].Name.Should().Be("x");
		}

		[Fact]
		public void ShouldSetParameters_WhenCreatingMemberMethod_GivenMethodInfoForFunction2()
		{
			Given.MethodInfo = typeof(SomeType).GetMethod("Function2");
			
			When(CreatingMemberMethod);

			Then.MemberMethod.Parameters[0].Type.BaseType.Should().Be("System.Boolean?");
			Then.MemberMethod.Parameters[0].Name.Should().Be("b");
			Then.MemberMethod.Parameters[1].Type.BaseType.Should().Be("System.Tuple<System.String, System.Int32>");
			Then.MemberMethod.Parameters[1].Name.Should().Be("o");
		}

		[Fact]
		public void ShouldSetParameters_WhenCreatingMemberMethod_GivenMethodInfoForFunction3()
		{
			Given.MethodInfo = typeof(SomeType).GetMethod("Function3");

			When(CreatingMemberMethod);

			Then.MemberMethod.Parameters[0].Type.BaseType.Should().Be("System.Int32");
			Then.MemberMethod.Parameters[0].Name.Should().Be("x");
			Then.MemberMethod.Parameters[1].Type.BaseType.Should().Be("System.String");
			Then.MemberMethod.Parameters[1].Name.Should().Be("s");
		}

		[Fact]
		public void ShouldReplaceTypes_WhenCreatingMemberMethod_GivenMethodInfoForFunction5()
		{
			Given.MethodInfo = typeof(SomeType).GetMethod("Function5");

			When(CreatingMemberMethod);

			Then.MemberMethod.ReturnType.BaseType.Should().Be("ISomeOtherTypeWrapper");
			Then.MemberMethod.Parameters[0].Type.BaseType.Should().Be("ISomeOtherTypeWrapper");
		}

		[Theory,
		InlineData("Function1", MemberAttributes.Public),
		InlineData("Function2", MemberAttributes.Public),
		InlineData("Function3", MemberAttributes.Public)]
		public void ShouldBePublic_WhenCreatingMemberMethod_GivenMethodInfo(string name, MemberAttributes attributes)
		{
			Given.MethodInfo = typeof(SomeType).GetMethod(name);
			
			When(CreatingMemberMethod);

			Then.MemberMethod.Attributes.Should().HaveFlag(attributes);
		}

		[Fact]
		public void ShouldThrow_WhenCreatingMemberMethod_GivenNonPublicMethodInfo()
		{
			Given.MethodInfo = typeof(SomeType).GetMethod("NotSupportedFunction", BindingFlags.NonPublic | BindingFlags.Instance);

			WhenLastActionDeferred(CreatingMemberMethod);

			ThenLastAction.ShouldThrow<NotSupportedException>();
		}

		private void CreatingMemberMethod()
		{
			Then.MemberMethod = Then.Target.GenerateMethodDeclaration(Given.MethodInfo);
		}
		#endregion

		#region MemberProperty
		[Fact]
		public void ShouldSetName_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");
			Given.PropertyInfo3 = typeof(SomeType).GetProperty("Property3");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Name.Should().Be("Property1");
			Then.MemberProperty2.Name.Should().Be("Property2");
			Then.MemberProperty3.Name.Should().Be("Property3");
		}

		[Fact]
		public void ShouldSetType_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");
			Given.PropertyInfo3 = typeof(SomeType).GetProperty("Property3");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Type.BaseType.Should().Be("System.Boolean");
			Then.MemberProperty2.Type.BaseType.Should().Be("System.Object");
			Then.MemberProperty3.Type.BaseType.Should().Be("ISomeOtherTypeWrapper");
		}

		[Fact]
		public void ShouldBePublic_WhenCreatingMemberProperty_GivenPropertyInfo()
		{
			Given.PropertyInfo1 = typeof(SomeType).GetProperty("Property1");
			Given.PropertyInfo2 = typeof(SomeType).GetProperty("Property2");
			Given.PropertyInfo3 = typeof(SomeType).GetProperty("Property3");

			When(CreatingMemberProperty);

			Then.MemberProperty1.Attributes.Should().HaveFlag(MemberAttributes.Public);
			Then.MemberProperty2.Attributes.Should().HaveFlag(MemberAttributes.Public);
			Then.MemberProperty3.Attributes.Should().HaveFlag(MemberAttributes.Public);
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
			Given.PropertyInfo3 = typeof(SomeType).GetProperty("Property3");

			When(CreatingMemberProperty);

			Then.MemberProperty1.HasGet.Should().BeTrue();
			Then.MemberProperty1.HasSet.Should().BeTrue();

			Then.MemberProperty2.HasGet.Should().BeTrue();
			Then.MemberProperty2.HasSet.Should().BeFalse();

			Then.MemberProperty3.HasGet.Should().BeTrue();
			Then.MemberProperty3.HasSet.Should().BeFalse();
		}

		private void CreatingMemberProperty()
		{
			Then.MemberProperty1 = Then.Target.GeneratePropertyDeclaration(Given.PropertyInfo1);
			Then.MemberProperty2 = Then.Target.GeneratePropertyDeclaration(Given.PropertyInfo2);
			Then.MemberProperty3 = Then.Target.GeneratePropertyDeclaration(Given.PropertyInfo3);
		}
		#endregion

		protected override void Creating()
		{
			var wrappedTypeDictionary = new Mock<IWrappedTypeDictionary>();

			wrappedTypeDictionary
				.Setup(x => x.Registered(It.IsIn(typeof(SomeType), typeof(SomeOtherType))))
				.Returns(true);

			wrappedTypeDictionary
				.Setup(x => x.GetContractNameFor(It.IsAny<Type>()))
				.Returns<Type>(t => $"I{t.Name}Wrapper");

			Then.Target = new MemberGenerator(wrappedTypeDictionary.Object);
		}

		public sealed class Thens
		{
			internal MemberGenerator Target;

			public CodeMemberMethod MemberMethod;
			
			public CodeMemberProperty MemberProperty1;
			public CodeMemberProperty MemberProperty2;
			public CodeMemberProperty MemberProperty3;
		}
	}
}