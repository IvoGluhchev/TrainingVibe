using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CrawlerService
{
    public static class Extensions
    {
        public static string CleanUpInnerText(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var sb = new StringBuilder(Regex.Replace(text, @"\s+", " ").Trim());
            sb.Replace("&nbsp;", string.Empty);

            // var result = Regex.Replace(text, @"\s+", " ").Trim();

            return sb.ToString();
        }
    }
}
