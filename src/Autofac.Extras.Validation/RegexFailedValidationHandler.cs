using Autofac.Extras.Validation.Properties;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Autofac.Extras.Validation
{
    internal class RegexFailedValidationHandler : GenericFailedValidationHandler<RegularExpressionAttribute>
    {
        #region Protected Methods

        protected override string CreateFailedValidationMessage(RegularExpressionAttribute attribute, ParameterInfo parameterInfo, object parameterValue) =>
            string.Format(Resources.Regex_Error, parameterInfo.Name, attribute.Pattern);

        #endregion Protected Methods
    }
}