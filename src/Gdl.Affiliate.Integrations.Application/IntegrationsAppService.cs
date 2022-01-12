using Gdl.Affiliate.Integrations.Localization;
using Volo.Abp.Application.Services;

namespace Gdl.Affiliate.Integrations
{
    /* Inherit your application services from this class.
     */
    public abstract class IntegrationsAppService : ApplicationService
    {
        protected IntegrationsAppService()
        {
            LocalizationResource = typeof(IntegrationsResource);
        }
    }
}
