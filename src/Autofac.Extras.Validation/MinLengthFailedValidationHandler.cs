using Autofac.Extras.Validation.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class MinLengthFailedValidationHandler : FailedValidationHandler<MinLengthAttribute>
    {
        #region Protected Methods

        protected override Exception CreateFailedValidationException(MinLengthAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentException(string.Format(Resources.MinLength_Error, parameterInfo.Name, attribute.Length), parameterInfo.Name);

        #endregion Protected Methods
    }
}