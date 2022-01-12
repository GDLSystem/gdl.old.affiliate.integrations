using Gdl.Affiliate.Integrations.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Gdl.Affiliate.Integrations.ConsoleApp
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(IntegrationsDomainModule),
        typeof(IntegrationsDomainSharedModule),
        typeof(IntegrationsMongoDbModule)
    )]
    public class ConsoleAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            context.Services.AddHostedService<ConsoleAppHostedService>();
        }
    }
}
