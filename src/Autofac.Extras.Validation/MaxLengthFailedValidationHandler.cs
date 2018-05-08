using Autofac.Extras.Validation.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class MaxLengthFailedValidationHandler : FailedValidationHandler<MaxLengthAttribute>
    {
        #region Protected Methods

        protected override Exception CreateFailedValidationException(MaxLengthAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentException(string.Format(Resources.MaxLength_Error, parameterInfo.Name, attribute.Length), parameterInfo.Name);

        #endregion Protected Methods
    }
}