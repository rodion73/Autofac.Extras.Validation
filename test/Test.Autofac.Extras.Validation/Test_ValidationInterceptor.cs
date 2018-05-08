using Castle.DynamicProxy;
using FluentAssertions;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Autofac.Extras.Validation

{
    public class Test_ValidationInterceptor
    {
        #region Public Methods

        [Fact]
        public void Intercept_WithInvalidArg_Throws()
        {
            var invocationMock = new Mock<IInvocation>();

            invocationMock.Setup(m => m.Arguments)
                .Returns(new[] { new Foo() });

            var testee = new ValidationInterceptor();

            testee.Invoking(t => t.Intercept(invocationMock.Object))
                .Should().Throw<ValidationException>();

            invocationMock.Verify(m => m.Proceed(), Times.Never());
        }

        [Fact]
        public void Intercept_WithValidArg_DoesntThrow()
        {
            var invocationMock = new Mock<IInvocation>();

            invocationMock.Setup(m => m.Arguments)
                .Returns(new[] { new Foo { Bar = "bar" } });

            var testee = new ValidationInterceptor();

            testee.Invoking(t => t.Intercept(invocationMock.Object))
                .Should().NotThrow();

            invocationMock.Verify(m => m.Proceed(), Times.Once());
        }

        #endregion Public Methods

        #region Private Classes

        private class Foo
        {
            #region Public Properties

            [Required]
            public string Bar { get; set; }

            #endregion Public Properties
        }

        #endregion Private Classes
    }
}