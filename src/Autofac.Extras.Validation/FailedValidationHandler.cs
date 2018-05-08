using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal abstract class FailedValidationHandler<T> : IFailedValidationHandler
        where T : ValidationAttribute
    {
        #region Protected Constructors

        protected FailedValidationHandler()
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        public void OnFailedValidation(ValidationAttribute attribute, ParameterInfo parameterInfo, object parameterValue)
        {
            if (attribute is T attr)
            {
                throw CreateFailedValidationException(attr, parameterInfo, parameterValue);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract Exception CreateFailedValidationException(T attribute, ParameterInfo parameterInfo, object parameterValue);

        #endregion Protected Methods
    }
}