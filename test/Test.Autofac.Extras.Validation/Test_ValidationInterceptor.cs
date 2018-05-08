using Autofac.Extras.DynamicProxy;
using FluentAssertions;
using System;
using Xunit;

namespace Autofac.Extras.Validation
{
    public class Test_ValidationInterceptor
    {
        #region Public Methods

        [Fact]
        public void Required()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.Required1(new object()))
                .Should().NotThrow();

            testee.Invoking(f => f.Required2(new object()))
                .Should().NotThrow();

            testee.Invoking(f => f.Required1(null))
                .Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.Required2(null))
                .Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("p");
        }

        #endregion Public Methods

        #region Private Methods

        private I CreateTestee<T, I>()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ValidationInterceptor>();

            builder.RegisterType<T>()
                .As<I>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ValidationInterceptor));

            var container = builder.Build();

            return container.Resolve<I>();
        }

        #endregion Private Methods
    }
}