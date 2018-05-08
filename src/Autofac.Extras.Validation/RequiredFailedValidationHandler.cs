﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class RequiredFailedValidationHandler : FailedValidationHandler<RequiredAttribute>
    {
        #region Protected Methods

        protected override Exception CreateFailedValidationException(
            RequiredAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            new ArgumentNullException(parameterInfo.Name);

        #endregion Protected Methods
    }
}