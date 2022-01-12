﻿using System.Linq;
using Flurl;

namespace Gdl.Affiliate.Integrations.Core.Extensions
{
    public static class UrlHelper
    {
        public static string ToHyperLinkText(this string urlString, string label = "Link")
        {
            if (urlString.IsNullOrEmpty()) return string.Empty;

            var url = new Url(urlString);

            return $"{label}: {url.Host}";
        }
        
        public static string GetShortKey(string shortLink)
        {
            return shortLink.Contains("/") ? shortLink.Trim().Split('/').LastOrDefault() : string.Empty;
        }
    }
}