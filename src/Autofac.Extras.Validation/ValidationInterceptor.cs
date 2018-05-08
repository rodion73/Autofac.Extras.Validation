﻿using Autofac.Extras.Validation.Properties;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    public class ValidationInterceptor : IInterceptor
    {
        #region Private Fields

        private static IEnumerable<IFailedValidationHandler> _failedValidationHandlers;

        #endregion Private Fields

        #region Public Constructors

        static ValidationInterceptor()
        {
            _failedValidationHandlers = typeof(ValidationInterceptor).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && t.IsAssignableTo<IFailedValidationHandler>())
                .Select(t => Activator.CreateInstance(t)).Cast<IFailedValidationHandler>()
                .ToArray();
        }

        #endregion Public Constructors

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

                if (parameterValue != null)
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
                    foreach (var h in _failedValidationHandlers)
                    {
                        h.OnFailedValidation(attribute, parameterInfo, parameterValue);
                    }

                    // fallback
                    OnFailedValidation(attribute, parameterInfo, parameterValue);
                }
            }
        }

        private void OnFailedValidation(ValidationAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            throw new ArgumentException(string.Format(Resources.Fallback_Error, parameterInfo.Name, parameterValue));

        private void ValidateComplexParameter(object parameterValue) =>
            Validator.ValidateObject(parameterValue, new ValidationContext(parameterValue));

        #endregion Private Methods
    }
}