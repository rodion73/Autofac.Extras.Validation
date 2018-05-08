using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal interface IFailedValidationHandler
    {
        #region Public Methods

        void OnFailedValidation(ValidationAttribute attribute, ParameterInfo parameterInfo, object parameterValue);

        #endregion Public Methods
    }
}