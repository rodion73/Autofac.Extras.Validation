using Autofac.Extras.Validation.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class EmailAddressFailedValidationHandler : FailedValidationHandler<EmailAddressAttribute>
    {
        #region Protected Methods

        protected override Exception CreateFailedValidationException(EmailAddressAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentException(string.Format(Resources.EmailAddress_Error, parameterInfo.Name), parameterInfo.Name);

        #endregion Protected Methods
    }
}