using Autofac.Extras.DynamicProxy;
using FluentAssertions;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Autofac.Extras.Validation
{
    public interface IFoo
    {
        #region Public Methods

        void Required([Required] object p);

        void Required2(object p);

        void MinLength([MinLength(2)] string p);

        void MinLength2(string p);

        void MaxLength([MaxLength(2)] string p);

        void MaxLength2(string p);

        void Email([EmailAddress] string p);

        void Email2(string p);

        void Regex([RegularExpression("\\d+")] string p);

        void Regex2(string p);

        void Complex(Bar p);

        #endregion Public Methods
    }

    public class Test_ValidationInterceptor
    {
        #region Public Methods

        [Fact]
        public void Required()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.Required(new object()))
                .Should().NotThrow();

            testee.Invoking(f => f.Required2(new object()))
                .Should().NotThrow();

            testee.Invoking(f => f.Required(null))
                .Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.Required2(null))
                .Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("p");
        }

        [Fact]
        public void MinLength()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.MinLength("123"))
                .Should().NotThrow();

            testee.Invoking(f => f.MinLength2("123"))
                .Should().NotThrow();

            testee.Invoking(f => f.MinLength("1"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.MinLength2("1"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");
        }

        [Fact]
        public void MaxLength()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.MaxLength("1"))
                .Should().NotThrow();

            testee.Invoking(f => f.MaxLength2("1"))
                .Should().NotThrow();

            testee.Invoking(f => f.MaxLength("123"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.MaxLength2("123"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");
        }

        [Fact]
        public void Email()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.Email("foo@bar.com"))
                .Should().NotThrow();

            testee.Invoking(f => f.Email2("foo@bar.com"))
                .Should().NotThrow();

            testee.Invoking(f => f.Email("123"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.Email2("123"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");
        }

        [Fact]
        public void Regex()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.Regex("123"))
                .Should().NotThrow();

            testee.Invoking(f => f.Regex2("123"))
                .Should().NotThrow();

            testee.Invoking(f => f.Regex("abc"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");

            testee.Invoking(f => f.Regex2("abc"))
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("p");
        }

        [Fact]
        public void Complex()
        {
            var testee = CreateTestee<Foo, IFoo>();

            testee.Invoking(f => f.Complex(new Bar { Baz = "buz" }))
                .Should().NotThrow();

            testee.Invoking(f => f.Complex(null))
                .Should().NotThrow();

            testee.Invoking(f => f.Complex(new Bar()))
                .Should().Throw<ValidationException>();
        }

        #endregion Public Methods

        #region Private Methods

        private I CreateTestee<T, I>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ValidationModule>();

            builder.RegisterType<Foo>().As<IFoo>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ValidationInterceptor));

            var container = builder.Build();
            return container.Resolve<I>();
        }

        #endregion Private Methods
    }

    public class Foo : IFoo
    {
        #region Public Methods

        public void Complex(Bar p)
        {
        }

        public void Required(object p)
        {
        }

        public void Required2([Required] object p)
        {
        }

        public void MinLength(string p)
        {
        }

        public void MinLength2([MinLength(2)] string p)
        {
        }

        public void MaxLength(string p)
        {
        }

        public void MaxLength2([MaxLength(2)] string p)
        {
        }

        public void Email(string p)
        {
        }

        public void Email2([EmailAddress] string p)
        {
        }

        public void Regex(string p)
        {
        }

        public void Regex2([RegularExpression("\\d+")] string p)
        {
        }

        #endregion Public Methods
    }

    public class Bar
    {
        #region Public Properties

        [Required]
        public string Baz { get; set; }

        #endregion Public Properties
    }
}