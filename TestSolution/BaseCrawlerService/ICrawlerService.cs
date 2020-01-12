using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseCrawlerService
{
    public interface ICrawlerService
    {
        List<Course> StartCrwaler(HttpClient client);
    }
}
