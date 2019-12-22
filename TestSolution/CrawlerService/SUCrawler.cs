using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CrawlerService
{
    public class SUCrawler : ISUCrawler
    {
        private static string url = $"https://softuni.bg/trainings/opencourses";
        private static string baseUrl = "https://softuni.bg";

        public List<Course> StartCrwaler(HttpClient client)
        {
            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, url);

            var divElements = htmlDocument.DocumentNode
                .Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("row course-in-category"))
                .ToList();

            var sliderCollection = htmlDocument.DocumentNode
                .Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("course-instance-box"))
                .ToList();

            // var tableCourses = TableListCourses(divElements);

            var sliedrCourses = GetSilderCourses(sliderCollection, client);

            return sliedrCourses;
        }
        
        private List<Course> GetSilderCourses(List<HtmlNode> sliderCollection, HttpClient client)
        {
            var courses = new List<Course>();

            foreach (var div in sliderCollection)
            {
                var course = new Course();

                course.Link = baseUrl + div.Descendants("a")
                    .FirstOrDefault()
                    .ChildAttributes("href")
                    .FirstOrDefault()
                    .Value;

                course.Title = div.Descendants("h4")
                    .FirstOrDefault()
                    .InnerText
                    .CleanUpInnerText();

                course.StartDate = div.Descendants("span")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "").Equals("course-date")).InnerText.CleanUpInnerText();

                course.Duration = div.Descendants("span")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "").Contains("course-length")).InnerText.CleanUpInnerText();

                course.Description = GetCourseDescription(course.Link, client);

                course.Price = GetCoursePrice(course.Link, client);

                courses.Add(course);
            }

            return courses;
        }

        private string GetCourseDescription(string link, HttpClient client)
        {
            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, link);

            var divElements = HttpClientUtil.GetNodeElements(htmlDocument,
                tagType: "div",
                className: "description collapsed");

            string courseLink = GetDetailPageLink(divElements);

            var description = divElements.FirstOrDefault().InnerText.CleanUpInnerText();
            var result = $"{description} {courseLink}";

            return result;
        }

        private static string GetDetailPageLink(IEnumerable<HtmlNode> divElements)
        {
            var result = string.Empty;

            var divElement = divElements
                .FirstOrDefault();

            if (divElement == null)
            {
                return result;   
            }

            var anchor = divElement.Descendants("a")
                .FirstOrDefault();
                
                if (anchor == null) return result;

            if (!anchor.HasAttributes) return result;

            var hrefAttribute = anchor.Attributes
                .FirstOrDefault(atr => atr.Name == "href");

            return hrefAttribute != null ? hrefAttribute.Value : result;
        }

        private string GetCoursePrice(string link, HttpClient client)
        {
            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, link);

            var price = HttpClientUtil.GetNodeElements(htmlDocument, tagType: "tr", className: "onsite")
                .FirstOrDefault()
                .Descendants("td")
                .Where(a => a.GetAttributeValue("class", "").Equals("price"))
                .FirstOrDefault()
                .InnerText;

            return price;
        }

        private List<Course> TableListCourses(List<HtmlNode> divElements)
        {
            var courses = new List<Course>();

            foreach (var div in divElements)
            {
                var course = new Course();

                var descriptionNode = div.Descendants("div")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "").Equals("col-md-9 description-box"));

                var boxNode = div.Descendants("div")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "").Equals("col-md-3 image-box"));

                course.Title = descriptionNode.Descendants("a")
                     .FirstOrDefault()
                     .ChildAttributes("title")
                     .FirstOrDefault()
                     .Value;

                course.Link = baseUrl + descriptionNode.Descendants("a")
                     .FirstOrDefault()
                     .ChildAttributes("href")
                     .FirstOrDefault()
                     .Value;
                
                var spanCollectionForDate = descriptionNode.SelectNodes("span");

                course.StartDate = spanCollectionForDate[0]
                    .NextSibling
                    .InnerText
                    .CleanUpInnerText();

                course.Duration = spanCollectionForDate[1]
                    .NextSibling
                    .InnerText
                    .CleanUpInnerText();

                course.Tags = GetTags();

                var h2 = div.Descendants("h2").FirstOrDefault().InnerText;

                var price = div.Descendants("div")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "").Equals("price"))
                    .Descendants("span")
                    .FirstOrDefault()
                    .InnerText;

                var link = div.Descendants("a")
                    .FirstOrDefault()
                    .ChildAttributes("href")
                    .FirstOrDefault()
                    .Value;

                var imageUrl = div.Descendants("img")
                    .FirstOrDefault()
                    .ChildAttributes("src")
                    .FirstOrDefault()
                    .Value;

                courses.Add(course);
            }

            return courses;
        }

        private string GetTags()
        {
            var tagList = new List<string>
            {
                "програмиране",
                "software",
                "programming",
                "softuni"
            };
            var result = JsonConvert.SerializeObject(tagList);

            return result;
        }
    }
}
