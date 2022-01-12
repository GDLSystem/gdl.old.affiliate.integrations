using Volo.Abp.Modularity;

namespace Gdl.Affiliate.Integrations
{
    [DependsOn(
        typeof(IntegrationsApplicationModule),
        typeof(IntegrationsDomainTestModule)
        )]
    public class IntegrationsApplicationTestModule : AbpModule
    {

    }
}