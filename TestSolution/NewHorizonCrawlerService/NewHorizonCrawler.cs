using System;
using System.Collections.Generic;
using System.Net.Http;
using BaseCrawlerService;
using Models;
using HtmlAgilityPack;

namespace NewHorizonCrawlerService
{
    public class NewHorizonCrawler : INewHorizonCrawler
    {
        private static string baseUrl = @"https://bg.newhorizons.bg";
        private static string upcomingCoursesUrl = baseUrl + @"/курсове-и-сертификати/предстоящи-курсове";

        public List<Course> StartCrwaler(HttpClient client)
        {
            throw new NotImplementedException();
        }

        private List<Category>
    }
}
