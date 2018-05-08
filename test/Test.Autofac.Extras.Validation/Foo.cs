using System.ComponentModel.DataAnnotations;

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

        void Complex(Bar p);

        #endregion Public Methods
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