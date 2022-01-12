namespace Gdl.Affiliate.Integrations.Permissions
{
    public static class IntegrationsPermissions
    {
        public const string GroupName = "Integrations";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = DashboardGroup + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class ShopinessClicks
        {
            public const string Default = GroupName + ".ShopinessClicks";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ShopinessConversions
        {
            public const string Default = GroupName + ".ShopinessConversions";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}