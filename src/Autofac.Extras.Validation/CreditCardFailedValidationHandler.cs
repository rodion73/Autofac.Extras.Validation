using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class CreditCardFailedValidationHandler : ArgumentExceptionFailedValidationHandler<CreditCardAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(CreditCardAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.CreditCard_Error, parameterInfo.Name);

        #endregion Protected Methods
    }
}