using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    public abstract class ArgumentExceptionFailedValidationHandler<T> : FailedValidationHandler<T>
        where T : ValidationAttribute
    {
        #region Protected Constructors

        protected ArgumentExceptionFailedValidationHandler()
        {
        }

        #endregion Protected Constructors

        #region Protected Methods

        protected override void OnFailedValidation(T attribute, ParameterInfo parameterInfo, object parameterValue) =>
            throw new ArgumentException(CreateFailedValidationMessage(attribute, parameterInfo, parameterValue), parameterInfo.Name);

        protected abstract string CreateFailedValidationMessage(T attribute, ParameterInfo parameterInfo, object parameterValue);

        #endregion Protected Methods
    }
}