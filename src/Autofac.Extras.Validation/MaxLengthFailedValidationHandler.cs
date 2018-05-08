using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class MaxLengthFailedValidationHandler : ArgumentExceptionFailedValidationHandler<MaxLengthAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(MaxLengthAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.MaxLength_Error, parameterInfo.Name, attribute.Length);

        #endregion Protected Methods
    }
}