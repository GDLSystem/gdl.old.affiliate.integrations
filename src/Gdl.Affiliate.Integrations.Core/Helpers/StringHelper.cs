using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using Gdl.Affiliate.Integrations.Core.Extensions;

namespace FacebookCommunityAnalytics.Api.Core.Helpers
{
    public static class StringHelper
    {
        private static Random random = new Random();
        private const string GreenColor = "color:forestgreen;";
        private const string RedColor = "color:red;";
        private const string BlackColor = "color:black;";
        private const string BoldText = "font-weight: bold;";

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            var randomed = Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();
            return $"{new string(randomed)}";
        }

        public static string RandomStringAll(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string specialChars = "!@#$%^&*";

            var randomed = Enumerable.Repeat(chars, length - 1)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();
            var randomedSpecialString = Enumerable.Repeat(specialChars, 1)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();
            return $"{new string(randomed)}{new string(randomedSpecialString)}";
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }
        
        public static string FormatGrowthColor(bool? isIncrease)
        {
            switch (isIncrease)
            {
                case true: return GreenColor + BoldText;
                case false: return RedColor + BoldText;
                default: return BlackColor;
            }
        }

        public static Color FormatGrowthColorBla(bool? isIncrease)
        {
            switch (isIncrease)
            {
                case true: return Color.Green;
                case false: return Color.Red;
                default: return Color.Black;
            }
        }

        public static string FormatDecimal(this string input)
        {
            if (input.IsNullOrEmpty())
            {
                return input;
            }
            input = input.Replace(".", string.Empty);
            //var cul = CultureInfo.GetCultureInfo("en-Us");
            return decimal.Parse(input).ToString("N0");
        }

        public static string ToHtmlBreak(this string input)
        {
            if (input.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return input.Replace("\n", "<br/>");
        }

        public static string ToQueryString(this object input)
        {
            var properties = from p in input.GetType().GetProperties()
                where p.GetValue(input, null) != null
                select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(input, null).ToString());
              
            string queryString = String.Join("&", properties.ToArray());
            return queryString;
        }
        
    }
}