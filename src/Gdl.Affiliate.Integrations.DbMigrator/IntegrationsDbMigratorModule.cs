using Gdl.Affiliate.Integrations.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Gdl.Affiliate.Integrations.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(IntegrationsMongoDbModule),
        typeof(IntegrationsApplicationContractsModule)
    )]
    public class IntegrationsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
