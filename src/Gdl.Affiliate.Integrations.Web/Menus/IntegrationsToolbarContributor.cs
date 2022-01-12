using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Gdl.Affiliate.Integrations.Web.Components.Toolbar.Impersonation;
using Gdl.Affiliate.Integrations.Web.Components.Toolbar.LoginLink;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Users;

namespace Gdl.Affiliate.Integrations.Web.Menus
{
    public class IntegrationsToolbarContributor : IToolbarContributor
    {
        public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return Task.CompletedTask;
            }

            if (!context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginLinkViewComponent)));
            }

            if (context.ServiceProvider.GetRequiredService<ICurrentUser>().FindImpersonatorUserId() != null)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(ImpersonationViewComponent), order: -1));
            }

            return Task.CompletedTask;
        }
    }
}
