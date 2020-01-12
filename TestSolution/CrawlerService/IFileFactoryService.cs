using Models;
using System.Collections.Generic;

namespace CrawlerService
{
    public interface IFileFactoryService
    {
        void CreateTextFile(List<Course> courses, string path);

        void CreateCsv(List<Course> courses, string path);

        void CreateWordPressCsv(List<PostWp> posts, string path);
    }
}
