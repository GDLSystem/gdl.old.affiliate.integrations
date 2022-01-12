using Gdl.Affiliate.Integrations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Gdl.Affiliate.Integrations.Web.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class IntegrationsPageModel : AbpPageModel
    {
        protected IntegrationsPageModel()
        {
            LocalizationResourceType = typeof(IntegrationsResource);
        }
    }
}