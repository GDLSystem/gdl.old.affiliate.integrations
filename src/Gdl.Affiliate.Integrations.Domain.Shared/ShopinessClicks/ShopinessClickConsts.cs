namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public static class ShopinessClickConsts
    {
        private const string DefaultSorting = "{0}Click asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShopinessClick." : string.Empty);
        }

    }
}