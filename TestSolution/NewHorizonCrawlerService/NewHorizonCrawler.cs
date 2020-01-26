using BaseCrawlerService;
using HtmlAgilityPack;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace NewHorizonCrawlerService
{
    public class NewHorizonCrawler : INewHorizonCrawler
    {
        private static readonly string baseUrl = @"https://bg.newhorizons.bg";
        private static readonly string upcomingCoursesUrl = baseUrl + @"/курсове-и-сертификати/предстоящи-курсове";
        private static readonly string courseProvider = "New Horizons";
        private static readonly string divCategoryClassName = "navxp-menu-simple";
        private static readonly string divSubCategoryClassName = "DnnModule DnnModule-";


        public List<Course> StartCrwaler(HttpClient client)
        {
            var courses = new List<Course>();
                       
            var mainCategories = GetCategories(client, upcomingCoursesUrl);

            //.Select(node => node.Descendants("a")).Distinct();

            return courses;
        }

        /// <summary>
        /// Gets the category links from the upcomingCoursesUrl
        /// the first is: Предстоящи курсове
        /// the last is: Определете нивото си
        /// </summary>
        /// <param name="htmlDocument">The HTML document.</param>
        /// <returns></returns>
        private List<Category> GetCategories(HttpClient client, string url)
        {
            HtmlDocument htmlDocument = HttpClientUtil.GetHtmlDocument(client, url);

            var categories = new List<Category>();

            var divElements = htmlDocument.DocumentNode
              .Descendants("div")
              .Where(node => node.GetAttributeValue("class", "").Equals("navxp-menu-simple"))
              .ToList();

            var anchorLists = divElements.FirstOrDefault().Descendants("li").Select(node => node.Descendants("a")).Distinct();

            foreach (var anchors in anchorLists)
            {
                foreach (var anchor in anchors)
                {
                    var category = new Category();

                    category.Link = anchor.ChildAttributes("href").FirstOrDefault().Value;

                    if (category.Link == upcomingCoursesUrl)
                    {
                        continue;
                    }

                    category.Name = anchor.InnerText.CleanUpInnerText();
                    category.Description = anchor.ChildAttributes("title").FirstOrDefault().Value;
                    category.CourseProvider = courseProvider;
                    categories.Add(category);
                }
            }

            return categories;
        }
    }
}
