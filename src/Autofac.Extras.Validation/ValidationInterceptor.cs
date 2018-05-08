using Castle.DynamicProxy;
using System.ComponentModel.DataAnnotations;

namespace Autofac.Extras.Validation
{
    public class ValidationInterceptor : IInterceptor
    {
        #region Public Methods

        public void Intercept(IInvocation invocation)
        {
            foreach (var arg in invocation.Arguments)
            {
                Validator.ValidateObject(arg, new ValidationContext(arg));
            }

            invocation.Proceed();
        }

        #endregion Public Methods
    }
}