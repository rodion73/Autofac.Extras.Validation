using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class EmailAddressFailedValidationHandler : ArgumentExceptionFailedValidationHandler<EmailAddressAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(EmailAddressAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.EmailAddress_Error, parameterInfo.Name);

        #endregion Protected Methods
    }
}