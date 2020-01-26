using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    class CategoryService
    {
        private List<string> mainCategories = new List<string>()
        {
            "Courses",
            "Classes",
            "Workshops",
            "Trainings",
            "Lessons",
            "",
            "",
            "",
            "",
            "",


        };

        private Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>
        {
            { "Development", new List<string> { "", "", "", } },
            { "Business", new List<string> { "", "", "", } },
            { "Finance and Accounting", new List<string> { "", "", "", } },
            { "It and Software", new List<string> { "", "", "", } },
            { "Office Productivity", new List<string> { "", "", "", } },
            { "Personal Development", new List<string> { "", "", "", } },
            { "Design", new List<string> { "", "", "", } },
            { "Marketing", new List<string> { "", "", "", } },
            { "Lifestyle", new List<string> { "", "", "", } },
            { "Photography", new List<string> { "", "", "", } },
            { "Health and Fitness", new List<string> { "", "", "", } },
            { "Music", new List<string> { "", "", "", } },
            { "Teaching and Academics", new List<string> { "", "", "", } },
        };
    }
}
