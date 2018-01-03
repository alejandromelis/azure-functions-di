using System;
using Microsoft.Azure.WebJobs;

namespace Inators.Azure.WebJobs.Extensions.Inject
{
    public static class InjectJobHostConfigurationExtensions
    {
        /// <summary>
        /// Enables use of Inject extensions
        /// </summary>
        /// <param name="config">The <see cref="JobHostConfiguration"/> to configure.</param>
        /// <param name="injectConfig">The <see cref="InjectExtensionConfiguration"/> to use.</param>
        public static void UseDependencyInjection(this JobHostConfiguration config, InjectExtensionConfiguration injectConfig = null)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (injectConfig == null)
            {
                injectConfig = new InjectExtensionConfiguration();
            }

            config.RegisterExtensionConfigProvider(injectConfig);
        }
    }
}