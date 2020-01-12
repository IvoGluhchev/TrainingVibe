using CsvHelper;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrawlerService.Progress
{
    public class FileFactoryService : IFileFactoryService
    {
        public void CreateCsv(List<Course> courses, string path )
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(courses);
            }
        }

        public void CreateWordPressCsv(List<PostWp> posts, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(posts);
            }
        }
        
        public void CreateTextFile(List<Course> courses, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                
            }
            try
            {
                //var sb = new StringBuilder();
                //var counter = 0;

                //foreach (var item in courses)
                //{
                //    counter++;
                //    sb.AppendLine($"Course Number: {counter}");
                //    sb.AppendLine($"Title: {item.Title}");
                //    sb.AppendLine($"StartDate: {item.StartDate}");
                //    sb.AppendLine($"Duration: {item.Duration}");
                //    sb.AppendLine($"Description: {item.Description}");
                //    sb.AppendLine($"Price: {item.Price}");
                //    sb.AppendLine($"Link: {item.Link}");
                //    sb.AppendLine($"Image: {item.ImageUrl}");
                //    sb.AppendLine();
                //}

                //using (var writer = new StreamWriter(path))
                //{
                //    writer.WriteLine(sb.ToString());
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
