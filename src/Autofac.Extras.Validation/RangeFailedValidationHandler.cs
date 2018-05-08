using Autofac.Extras.Validation.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class RangeFailedValidationHandler : FailedValidationHandler<RangeAttribute>
    {
        #region Protected Methods

        protected override void OnFailedValidation(RangeAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            throw new ArgumentOutOfRangeException(parameterInfo.Name,
                string.Format(Resources.Range_Error, parameterInfo.Name, attribute.Minimum, attribute.Maximum));

        #endregion Protected Methods
    }
}