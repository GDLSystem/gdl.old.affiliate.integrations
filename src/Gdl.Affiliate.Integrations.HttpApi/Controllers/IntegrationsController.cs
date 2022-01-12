using Gdl.Affiliate.Integrations.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Gdl.Affiliate.Integrations.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class IntegrationsController : AbpControllerBase
    {
        protected IntegrationsController()
        {
            LocalizationResource = typeof(IntegrationsResource);
        }
    }
}