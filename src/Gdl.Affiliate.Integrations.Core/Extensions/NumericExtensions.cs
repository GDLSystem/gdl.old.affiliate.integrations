namespace Gdl.Affiliate.Integrations.Core.Extensions
{
    public static class NumericExtensions
    {
        public static string ToCommaStyle(this decimal value, string zeroString = "---")
        {
            if (value == 0)
            {
                return zeroString;
            }

            return $"{value:N0}";
        }

        public static string ToCommaStyle(this object value, string zeroString = "---")
        {
            decimal.TryParse(value.ToString(), out var number);
            return ToCommaStyle(number, zeroString);
        }
    }
}