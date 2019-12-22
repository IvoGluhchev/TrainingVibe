using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerService
{
    public class Course
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Duration { get; set; }

        public string MinParticipants { get; set; }

        public string MaxParticipants { get; set; }

        public string Category { get; set; }

        /// <summary>
        /// Json Collection
        /// </summary>
        public string Tags { get; set; }
    }
}
