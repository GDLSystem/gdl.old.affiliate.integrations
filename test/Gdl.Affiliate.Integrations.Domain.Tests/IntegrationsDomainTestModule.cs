using Gdl.Affiliate.Integrations.MongoDB;
using Volo.Abp.Modularity;

namespace Gdl.Affiliate.Integrations
{
    [DependsOn(
        typeof(IntegrationsMongoDbTestModule)
        )]
    public class IntegrationsDomainTestModule : AbpModule
    {

    }
}