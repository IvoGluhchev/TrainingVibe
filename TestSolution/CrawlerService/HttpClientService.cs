﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace CrawlerService
{
    public class HttpClientService
    {
        private static HttpClient _httpClient;

        public static HttpClient Client
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }

                return _httpClient; }
        }
    }
}
