using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class MinLengthFailedValidationHandler : ArgumentExceptionFailedValidationHandler<MinLengthAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(MinLengthAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.MinLength_Error, parameterInfo.Name, attribute.Length);

        #endregion Protected Methods
    }
}