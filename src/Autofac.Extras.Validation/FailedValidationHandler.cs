using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    public abstract class FailedValidationHandler<T> : IFailedValidationHandler
        where T : ValidationAttribute
    {
        protected FailedValidationHandler()
        {
        }

        public void OnFailedValidation(ValidationAttribute attribute, ParameterInfo parameterInfo, object parameterValue)
        {
            if (attribute is T attr)
            {
                OnFailedValidation(attr, parameterInfo, parameterValue);
            }
        }

        protected abstract void OnFailedValidation(T attribute, ParameterInfo parameterInfo, object parameterValue);
    }
}