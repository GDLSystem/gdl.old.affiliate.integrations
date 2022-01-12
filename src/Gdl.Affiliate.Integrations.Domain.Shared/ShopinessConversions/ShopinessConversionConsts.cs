namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public static class ShopinessConversionConsts
    {
        private const string DefaultSorting = "{0}ConversionItemId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShopinessConversion." : string.Empty);
        }

    }
}