namespace ExampleApp
{
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;

    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Context;

    public class AppSettingsConvention : ISubDependencyResolver
    {
        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return ConfigurationManager.AppSettings.AllKeys.ToList()
                    .Contains(dependency.DependencyKey)
                && TypeDescriptor
                    .GetConverter(dependency.TargetType)
                    .CanConvertFrom(typeof(string));
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return TypeDescriptor
                .GetConverter(dependency.TargetType)
                .ConvertFrom(
                    ConfigurationManager.AppSettings[dependency.DependencyKey]);
        }
    }
}