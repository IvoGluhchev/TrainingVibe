using BaseCrawlerService;
using Common;
using CrawlerService.Progress;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models;
using NewHorizonCrawlerService;
using ProgressCrawlerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerService
{
    class Program
    {
        private static string path = @"C:\Users\user\Desktop\TrainingVibe\TestSolution\CrawlerService\course_data_files";
        static void Main(string[] args)
        {
            var client = HttpClientService.Client;
            var fileService = new FileFactoryService();

            StartProgCrawler(client, fileService);
            StartSuCrawler(client, fileService);
        }

        private static void StartNewHorizonCrawler(HttpClient client, FileFactoryService fileService)
        {
            var nhCrawler = new NewHorizonCrawler();
            var courses = nhCrawler.StartCrwaler(client);

            if (!Directory.Exists(path + $"\\NewHorizon\\"))
            {
                Directory.CreateDirectory(path + $"\\NewHorizon\\");
            }

            var posts = GetWpPosts(courses);

            fileService.CreateWordPressCsv(posts, path + $"\\NewHorizon\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}_prog_c{FileExtensionConst.Csv}");
        }

        private static void StartProgCrawler(HttpClient client, FileFactoryService fileService)
        {
            var proCrwaler = new ProgressCrawler();
            var courses = proCrwaler.StartCrwaler(client);

            if (!Directory.Exists(path + $"\\Progress\\"))
            {
                Directory.CreateDirectory(path + $"\\Progress\\");
            }

            var posts = GetWpPosts(courses);

            fileService.CreateWordPressCsv(posts, path + $"\\Progress\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}_prog_c{FileExtensionConst.Csv}");
            //  fileService.CreateCsv(proResult, $"{PathConst.ProgPath}\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}_prog_c{FileExtensionConst.Csv}");
        }

        private static void StartSuCrawler(HttpClient client, FileFactoryService fileService)
        {
            var suCrawler = new SUCrawler();
            var courses = suCrawler.StartCrwaler(client);

            if (!Directory.Exists(path + "\\SoftUni\\"))
            {
                Directory.CreateDirectory(path + "\\SoftUni\\");
            }

            var posts = GetWpPosts(courses);

            fileService.CreateWordPressCsv(posts, path + $"\\SoftUni\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}_su_c{FileExtensionConst.Csv}");
            // fileService.CreateCsv(suResult, $"{PathConst.SuPath}\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}_su_c{FileExtensionConst.Csv}");
        }

        private static List<PostWp> GetWpPosts(List<Course> courses)
        {
            var posts = new List<PostWp>();

            foreach (var course in courses)
            {
                var post = course.MapToPostWp();
                posts.Add(post);
            }

            return posts;
        }

        private static ServiceProvider ServiceProvider()
        {
            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddLogging(opt => { opt.AddConsole().SetMinimumLevel(LogLevel.Debug); })
                .AddSingleton<IFileFactoryService, FileFactoryService>()
                .AddSingleton<ISUCrawler, SUCrawler>()
                .BuildServiceProvider();

            return serviceCollection;
        }

        private static async Task StartCrwaler(string url)
        {
            var client = new HttpClient();
            var html = client.GetStringAsync(url).Result;
            var htmlDocuments = new HtmlDocument();
            htmlDocuments.LoadHtml(html);

            var divs = htmlDocuments.DocumentNode
                .Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("versions-item"))
                .ToList();

            foreach (var div in divs)
            {
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

                //var h2 = div.Descendants("h2").FirstOrDefault().InnerText;
                //var h2 = div.Descendants("h2").FirstOrDefault().InnerText;
                //var h2 = div.Descendants("h2").FirstOrDefault().InnerText;
            }

        }
    }
}
