using Autofac.Builder;
using Autofac.Extras.DynamicProxy;

namespace Autofac.Extras.Validation
{
    public static class RegistrationExtensions
    {
        #region Public Methods

        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle> EnableParametersValidation<TLimit, TActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TStyle> builder) =>
                builder.InterceptedBy(typeof(ValidationInterceptor));

        #endregion Public Methods
    }
}