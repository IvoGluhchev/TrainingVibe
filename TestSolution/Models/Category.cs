using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string Tags { get; set; }

        public string Description { get; set; }

        public string CourseProvider { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}
