using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Gdl.Affiliate.Integrations.Web
{
    [Dependency(ReplaceServices = true)]
    public class IntegrationsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Integrations";
    }
}
