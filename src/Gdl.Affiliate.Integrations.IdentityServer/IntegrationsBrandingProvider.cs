using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Gdl.Affiliate.Integrations
{
    [Dependency(ReplaceServices = true)]
    public class IntegrationsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Integrations";
    }
}
