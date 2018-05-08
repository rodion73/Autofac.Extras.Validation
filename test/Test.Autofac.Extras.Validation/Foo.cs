using System.ComponentModel.DataAnnotations;

namespace Autofac.Extras.Validation
{
    public interface IFoo
    {
        #region Public Methods

        void Required1([Required] object p);

        void Required2(object p);

        #endregion Public Methods
    }

    public class Foo : IFoo
    {
        #region Public Methods

        public void Required1(object p)
        {
        }

        public void Required2([Required] object p)
        {
        }

        #endregion Public Methods
    }
}