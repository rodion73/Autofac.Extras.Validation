using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class MinLengthFailedValidationHandler : FailedValidationHandler<MinLengthAttribute>
    {
        #region Protected Methods

        protected override Exception CreateFailedValidationException(
            MinLengthAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentException();

        #endregion Protected Methods
    }
}