namespace Autofac.Extras.Validation
{
    public class ValidationModule : Module
    {
        #region Protected Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<IFailedValidationHandler>())
                .As<IFailedValidationHandler>()
                .SingleInstance();

            builder.RegisterType<ValidationInterceptor>();
        }

        #endregion Protected Methods
    }
}