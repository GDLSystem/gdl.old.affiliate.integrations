using System.Collections.Generic;

namespace Gdl.Affiliate.Integrations.Core.Const
{
    public static class GlobalConsts
    {
        public static int[] PAGE_SIZES_CONST = { 10, 25, 50, 75, 100 };
        public static List<int> MONTH_OF_YEAR = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public static string DateTimeFormat = "dd/MM/yyyy HH:mm";
        public static string DateFormat = "dd/MM/yyyy";
        
        public const string BaseAffiliateDomain = "https://gdll.vn";
        public const string GDLDomain = "https://gdl.vn";
        public const string HPDDomain = "happyday.sale";
        public const string YANDomain = "yin.vn";

        public const string DefaultAvatar = "images/default-avatar.jpg";
    }
}
