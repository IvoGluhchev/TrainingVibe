using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CrawlerService
{
    public static class HttpClientUtil
    {
        public static HtmlDocument GetHtmlDocument(HttpClient client, string link)
        {
            var html = client.GetStringAsync(link).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument;
        }

        public static IEnumerable<HtmlNode> GetNodeElements(HtmlDocument htmlDocument, string tagType, string className)
        {
            var elements = htmlDocument.DocumentNode
              .Descendants(tagType)
              .Where(node => node.GetAttributeValue("class", "").Equals(className));

            return elements;
        }
    }
}
