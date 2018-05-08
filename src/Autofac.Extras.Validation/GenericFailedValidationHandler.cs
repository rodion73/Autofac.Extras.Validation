using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    public abstract class GenericFailedValidationHandler<T> : FailedValidationHandler<T>
        where T : ValidationAttribute
    {
        #region Protected Constructors

        protected GenericFailedValidationHandler()
        {
        }

        #endregion Protected Constructors

        #region Protected Methods

        protected override Exception CreateFailedValidationException(T attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentException(CreateFailedValidationMessage(attribute, parameterInfo, parameterValue), parameterInfo.Name);

        protected abstract string CreateFailedValidationMessage(T attribute, ParameterInfo parameterInfo, object parameterValue);

        #endregion Protected Methods
    }
}