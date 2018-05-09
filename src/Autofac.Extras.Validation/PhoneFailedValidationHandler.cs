using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class PhoneFailedValidationHandler : ArgumentExceptionFailedValidationHandler<PhoneAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(PhoneAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.Phone_Error, parameterInfo.Name);

        #endregion Protected Methods
    }
}