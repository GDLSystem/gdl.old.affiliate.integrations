using Gdl.Affiliate.Integrations.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Gdl.Affiliate.Integrations.Permissions
{
    public class IntegrationsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(IntegrationsPermissions.GroupName);

            myGroup.AddPermission(IntegrationsPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(IntegrationsPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(IntegrationsPermissions.MyPermission1, L("Permission:MyPermission1"));

            var shopinessClickPermission = myGroup.AddPermission(IntegrationsPermissions.ShopinessClicks.Default, L("Permission:ShopinessClicks"));
            shopinessClickPermission.AddChild(IntegrationsPermissions.ShopinessClicks.Create, L("Permission:Create"));
            shopinessClickPermission.AddChild(IntegrationsPermissions.ShopinessClicks.Edit, L("Permission:Edit"));
            shopinessClickPermission.AddChild(IntegrationsPermissions.ShopinessClicks.Delete, L("Permission:Delete"));

            var shopinessConversionPermission = myGroup.AddPermission(IntegrationsPermissions.ShopinessConversions.Default, L("Permission:ShopinessConversions"));
            shopinessConversionPermission.AddChild(IntegrationsPermissions.ShopinessConversions.Create, L("Permission:Create"));
            shopinessConversionPermission.AddChild(IntegrationsPermissions.ShopinessConversions.Edit, L("Permission:Edit"));
            shopinessConversionPermission.AddChild(IntegrationsPermissions.ShopinessConversions.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IntegrationsResource>(name);
        }
    }
}