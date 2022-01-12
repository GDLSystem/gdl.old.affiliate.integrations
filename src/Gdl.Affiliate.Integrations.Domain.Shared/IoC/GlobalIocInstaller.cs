using Gdl.Affiliate.Integrations.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Gdl.Affiliate.Integrations.IoC
{
    public static class GlobalIocInstaller
    {
        public static void Configure(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var configuration = context.Services.GetConfiguration();

            // global config
            var globalConfigurationSection = configuration.GetSection(nameof(GlobalConfiguration));
            var globalConfiguration = globalConfigurationSection.Get<GlobalConfiguration>();
            if (globalConfiguration != null) services.AddSingleton(globalConfiguration);
        }
    }
}
