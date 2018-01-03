using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Inators.Azure.WebJobs.Extensions.Inject
{
    public class InjectExtensionConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var registerServices = GetRegisterServicesInstance(context);
            var services = new ServiceCollection();
            registerServices.PopulateServiceCollection(services);
            var serviceProvider = services.BuildServiceProvider(true);

            context
                .AddBindingRule<InjectAttribute>()
                .Bind(new InjectBindingProvider(serviceProvider));
            var registry = context.Config.GetService<IExtensionRegistry>();
            var filter = new ScopeCleanupFilter();
            registry.RegisterExtension(typeof(IFunctionInvocationFilter), filter);
            registry.RegisterExtension(typeof(IFunctionExceptionFilter), filter);
        }
        public string RegisterServicesAssemblyQualifiedName { get; set; }

        private IRegisterServices GetRegisterServicesInstance(ExtensionConfigContext context)
        {
            var injectConfiguration = context.GetConfig(this, "inject").ToObject<InjectConfiguration>();
            var registerType = Type.GetType(injectConfiguration.RegisterServicesAssemblyQualifiedName);
            return (IRegisterServices)Activator.CreateInstance(registerType);
        }
    }
}