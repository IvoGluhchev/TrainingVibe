using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CrawlerService
{
    public class ProgressCrawler : ICrawlerService
    {
        private static string baseUrl = $"https://progressbg.net";

        public List<Course> StartCrwaler(HttpClient client)
        {
            var courses = new List<Course>();
            var className = "menu-item menu-item-type-custom menu-item-object-custom";

            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, baseUrl);

            var divElements = htmlDocument.DocumentNode
                .Descendants("li")
                .Where(node => node.GetAttributeValue("class", "").Contains(className) && node.HasAttributes)
                .ToList();

            var uniqueLinks = new Dictionary<string, string>();

            foreach (var div in divElements)
            {
                // Flatten the collection
                // var anchors = div.Descendants("li").SelectMany(node => node.Descendants("a")).Distinct();

                var anchorsList = div.Descendants("li").Select(node => node.Descendants("a")).Distinct();

                foreach (var anchors in anchorsList)
                {
                    var tag = anchors.FirstOrDefault().InnerText;

                    foreach (var anchor in anchors)
                    {
                        var link = anchor.ChildAttributes("href").FirstOrDefault().Value;

                        if (link.Length > baseUrl.Length && !uniqueLinks.ContainsKey(link))
                        {
                            var course = CrawlPage(client, link);

                            if (course != null)
                            {
                                course.Link = link;
                                course.Tags = GetTags(tag, link);
                                courses.Add(course);
                            }

                            uniqueLinks.Add(link, tag);
                        }
                    }
                }
            }

            return courses;
        }


        private Course CrawlPage(HttpClient client, string url)
        {
            var course = new Course();
            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, url);

            var divElements = htmlDocument.DocumentNode
                .Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "").Contains("tabs-content entry-content"))
                .FirstOrDefault();

            if (divElements != null)
            {
                var htmlNodes = htmlDocument.DocumentNode.Descendants("div");

                course.Title = GetTitle(htmlDocument);

                course.ImageUrl = GetImageUrl(htmlNodes);

                var description = divElements.Descendants("li")
                     .Where(node => node.GetAttributeValue("id", "").Equals("t1Tab"))
                     .FirstOrDefault();

                course.Description = description != null ? description.InnerText : string.Empty;

                var grafikTab = divElements.Descendants("li")
                    .Where(node => node.GetAttributeValue("id", "").Equals("grafikTab"))
                    .FirstOrDefault();

                if (grafikTab != null)
                {
                    course.StartDate = grafikTab.InnerText;

                    course.Price = grafikTab.Descendants("a")
                        .FirstOrDefault(a => a.GetAttributeValue("class", "").Contains("button orange "))
                        .InnerText;
                }

                return course;
            }

            return null;
        }

        private string GetTitle(HtmlDocument htmlDocument)
        {
            var title = htmlDocument.DocumentNode
                .Descendants("h1")
                .FirstOrDefault(node => node.GetAttributeValue("id", "").Contains("page-title"));

            //var title = htmlNodes
            //   .Where(node => node.Descendants("h1").Contains("page-title"))
            //   .Where( desc => desc.GetAttributeValue("id", "")

            return title != null ? title.InnerText : string.Empty;
        }

        private string GetImageUrl(IEnumerable<HtmlNode> htmlNodes)
        {
            var image = htmlNodes
                .FirstOrDefault(node => node.GetAttributeValue("class", "").Contains("entry-content"))
                .Descendants("img")
                .FirstOrDefault()
                .ChildAttributes("src")
                .FirstOrDefault();

            if (image == null)
            {
                return string.Empty;
            }

            if (image.Value.Contains(baseUrl))
            {
                return image.Value;
            }

            return $"{baseUrl}{image.Value}";
        }


        private string GetTags(string tag, string link)
        {
            var endIndex = (link.Length - (baseUrl.Length + 2));
            var startIndex = (baseUrl.Length + 1);
            var tagList = new List<string>
            {
                tag,
                link.Substring(startIndex, endIndex),
                "progress"
            };
            var result = JsonConvert.SerializeObject(tagList);

            return result;
        }
    }
}
