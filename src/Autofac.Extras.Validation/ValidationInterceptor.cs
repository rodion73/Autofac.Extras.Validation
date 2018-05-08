using Castle.DynamicProxy;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    public class ValidationInterceptor : IInterceptor
    {
        #region Public Methods

        public void Intercept(IInvocation invocation)
        {
            var interfaceParameters = invocation.Method.GetParameters();
            var classParameters = invocation.MethodInvocationTarget.GetParameters();

            for (var i = 0; i < interfaceParameters.Length; i++)
            {
                var parameterValue = invocation.Arguments[i];
                ValidateParamater(interfaceParameters[i], parameterValue);
                ValidateParamater(classParameters[i], parameterValue);

                var parameterType = interfaceParameters[i].ParameterType;
                if ((parameterType.IsClass || parameterType.IsInterface) && parameterValue != null)
                {
                    ValidateComplexParameter(parameterValue);
                }
            }

            invocation.Proceed();
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateParamater(ParameterInfo parameterInfo, object parameterValue)
        {
            foreach (var attribute in parameterInfo.GetCustomAttributes<ValidationAttribute>())
            {
                if (!attribute.IsValid(parameterValue))
                {
                    if (attribute is RequiredAttribute attr)
                    {
                        OnFailedValidation(attr, parameterInfo, parameterValue);
                        continue;
                    }
                }
            }
        }

        private void ValidateComplexParameter(object parameterValue)
        {
            Validator.ValidateObject(parameterValue, new ValidationContext(parameterValue));
        }

        private void OnFailedValidation(RequiredAttribute attribute, ParameterInfo parameterInfo, object parameterValue)
        {
            throw new ArgumentNullException(parameterInfo.Name);
        }

        #endregion Private Methods
    }
}