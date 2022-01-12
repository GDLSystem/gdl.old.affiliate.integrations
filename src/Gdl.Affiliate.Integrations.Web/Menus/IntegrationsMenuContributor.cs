using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Gdl.Affiliate.Integrations.Localization;
using Gdl.Affiliate.Integrations.Permissions;
using Volo.Abp.Account.Localization;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using Volo.Saas.Host.Navigation;

namespace Gdl.Affiliate.Integrations.Web.Menus
{
    public class IntegrationsMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public IntegrationsMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<IntegrationsResource>();
            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    IntegrationsMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            //Host Dashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    IntegrationsMenus.HostDashboard,
                    l["Menu:Dashboard"],
                    "~/HostDashboard",
                    icon: "fa fa-line-chart",
                    order: 2
                ).RequirePermissions(IntegrationsPermissions.Dashboard.Host)
            );

            //Tenant Dashboard
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    IntegrationsMenus.TenantDashboard,
                    l["Menu:Dashboard"],
                    "~/Dashboard",
                    icon: "fa fa-line-chart",
                    order: 2
                ).RequirePermissions(IntegrationsPermissions.Dashboard.Tenant)
            );

            //Saas
            context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 5;

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 2);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    IntegrationsMenus.ShopinessClicks,
                    l["Menu:ShopinessClicks"],
                    url: "/ShopinessClicks",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: IntegrationsPermissions.ShopinessClicks.Default)
            );

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    IntegrationsMenus.ShopinessConversions,
                    l["Menu:ShopinessConversions"],
                    url: "/ShopinessConversions",
                    icon: "fa fa-file-alt",
                    requiredPermissionName: IntegrationsPermissions.ShopinessConversions.Default)
            );
            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "~";
            var uiResource = context.GetLocalizer<AbpUiResource>();
            var accountResource = context.GetLocalizer<AccountResource>();
            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{identityServerUrl.EnsureEndsWith('/')}Account/SecurityLogs", target: "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}