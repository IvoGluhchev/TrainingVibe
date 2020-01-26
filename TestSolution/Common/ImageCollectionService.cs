using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ImageCollectionService
    {
        public static string GetSoftwareImage(string image, string title) 
        {
            if (!string.IsNullOrEmpty(image))
            {
                return image;
            }

            if (softwareImageLinksCollection.ContainsKey(title))
            {
                return softwareImageLinksCollection[title];
            }

            return GetRandomSoftwareImage();
        }

        public static string GetRandomSoftwareImage()
        {
            var ran = random.Next(defaultSoftwareImages.Count + 1);

            return defaultSoftwareImages[ran];
        }

        public static string GetRandomBusinessImage()
        {
            var ran = random.Next(defaultBusinessImages.Count + 1);
            
            return defaultBusinessImages[ran];
        }

        private static string GetDefaultImage()
        {
            var collection = new List<string>();
            collection.AddRange(defaultSoftwareImages);
            collection.AddRange(defaultBusinessImages);

            var ran = random.Next(collection.Count + 1);

            return collection[ran];
        }

        private static Random random = new Random();

        /// <summary>
        /// Collection for lookup by the key for different software technologies
        /// </summary>
        private static Dictionary<string, string> softwareImageLinksCollection = new Dictionary<string, string>
        {
            {"c#", $"https://cdn.worldvectorlogo.com/logos/c--4.svg" },
            {"java", $"https://cdn.worldvectorlogo.com/logos/java-4.svg" },
            {"python", $"https://cdn.worldvectorlogo.com/logos/python-4.svg" },
            {"javascript", $"https://cdn.worldvectorlogo.com/logos/javascript.svg" },
            {"react", $"https://cdn.worldvectorlogo.com/logos/react-1.svg" },
            {"angular", $"https://cdn.worldvectorlogo.com/logos/angular-3.svg" },
            {"angularjs", $"https://cdn.worldvectorlogo.com/logos/angular.svg" },
            {"php", $"https://cdn.worldvectorlogo.com/logos/php-1.svg" },
            {"devops", $"https://dpsvdv74uwwos.cloudfront.net/statics/img/product-pages/devops.png" },
            {"git", $"https://cdn.worldvectorlogo.com/logos/git.svg" },
            {"wordpress", $"https://cdn.worldvectorlogo.com/logos/wordpress-icon.svg" },
            {"docker", $"https://cdn.worldvectorlogo.com/logos/docker.svg" },
            {"azure", $"https://cdn.worldvectorlogo.com/logos/microsoft-azure-2.svg" },
            {"microsoft azure", $"https://cdn.worldvectorlogo.com/logos/microsoft-azure-2.svg" },
            {"microsoft", $"https://cdn.worldvectorlogo.com/logos/microsoft.svg" },
            {"word", $"https://cdn.worldvectorlogo.com/logos/microsoft-word-2013-logo.svg" },
            {"excel", $"https://cdn.worldvectorlogo.com/logos/excel-4.svg" },
            {"sql", $"https://cdn.worldvectorlogo.com/logos/microsoft-sql-server.svg" },
            { "oracle", $"https://cdn.worldvectorlogo.com/logos/oracle-logo-1.svg"},
            { "mysql", $"https://cdn.worldvectorlogo.com/logos/mysql.svg"},
            { "poatgresql", $"https://cdn.worldvectorlogo.com/logos/postgresql.svg"},
            { "nodejs", $"https://cdn.worldvectorlogo.com/logos/nodejs-1.svg"},
            { "node", $"https://cdn.worldvectorlogo.com/logos/nodejs-1.svg"},
            { "data", $"https://telecomreviewasia.com/images/stories/2019/12/Big-Data-Asias-newest-socio-economic-ally.jpg"},

        };

        /// <summary>
        /// Random Images depicting software process and technologies
        /// </summary>
        private static List<string> defaultSoftwareImages = new List<string> 
        {
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRTJ-IrX75gJxM-v6UJn5gq0FwJVz-M3BQIHU7W01Ne9IP6db_&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSA4UCnkNwBzatjHtlQHFgzmSe6TOnC_whFI8yV2Mo14zYne78K&s",
            $"https://cdn.pixabay.com/photo/2015/12/04/14/05/code-1076533__340.jpg",
            $"https://cdn.pixabay.com/photo/2017/08/06/13/01/laptop-2592316__340.jpg",
            $"https://cdn.pixabay.com/photo/2017/08/06/04/11/laptop-2588606__340.jpg",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOS0bdPIS3_Jgj7zR4iThx6lcs8vTHjZiQlqqBV_zoHg5BYVM2&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-2YD7dw-KhgfsJ7PqZdZuDC7b1YTXJi-edsyNR4O_p-l8bOXm&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtCzTeLhLr3lchz8uRg3UepsLm7KvcCrONlrb6TtagsqrZnVj9&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdq4nz3rXgcbkLxac7RX2GTLTtkLwAJk1LxRlc4c9A9oDZdZFj&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyPZYWsyMw4AKfiFhJnA7M0Fx8klwi05sW4TEJYp8reMjfQVgU&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRTJ-IrX75gJxM-v6UJn5gq0FwJVz-M3BQIHU7W01Ne9IP6db_&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTp-pua-8LfIcXn7AVO_oqLETkteOWw8IBsSf7mWK5T7-1DogOvng&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyq_uEGVpGJpfb9tDeid1BkgYc_yfMKeWIRwSZIQdnYT1db6VYSQ&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGukluJXkVlpWEYq3aBkUPF1W-phy41B8lW44NAdM3mgc80Xys&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAoHkXEIeljuWdbDxEoJT1bCRiKBOPUdpRZQdD4lrXm3yYI9uc&s",
            $"https://img.pngio.com/software-development-clipart-computer-company-software-software-development-png-880_561.png",
            $"https://img.pngio.com/computer-software-software-development-computer-programming-software-development-png-728_673.jpg",
            $"https://img.pngio.com/custom-web-application-development-software-development-hd-png-software-development-png-840_700.png",
            $"https://img.pngio.com/software-developer-png-free-software-developerpng-transparent-software-development-png-900_1020.png",
            $"https://img.pngio.com/ssoft-solution-customized-software-development-company-in-bhopal-software-development-png-570_490.png",
            $"https://img.pngio.com/web-development-software-development-web-design-web-application-software-development-png-728_633.jpg",
            $"https://img.pngio.com/about-custom-software-development-geniuszone-software-development-png-1000_1000.png",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkj6qvyDc_7oUcvPvs8zUE-jcvAblWIt5J0kw83jRmu30Zhdi2&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRePJ4oudnqrJbEdRLTyxdBGY_zwVppXbn5cSD21dmwYcmBkPG3&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgu111rPJUPrAgwFcaRCDVnOl1LfvUKB-pY7V6r37JuxaPUMXS&s",
            $"https://twitgoo.com/wp-content/uploads/2019/08/IMG_1463.png"
        };

        /// <summary>
        /// Random Images depicting business processes
        /// </summary>
        private static List<string> defaultBusinessImages = new List<string>
        {
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcdqoyECTZBWK1VNyHcExNcBkSdkuKsJNKRA3LbnH0v07_hnkt&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9W0dPHoBNzVBaqgFEpKyffvZbLxULEOaSd8r2j0KcPr8S2iMB&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRc9dE704lSF_xHhlGn3X3MUodMH3KQw8b4SDlrvI5NWhE3K-BY&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWRRE-9n7xAkGob0BOj8sKz2SdLhl0J-HfXnR2EtjSQvHG87Y1&s",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUTb2ODRQAEUmTEgOWA1yjKG9bRf4KFu5OF3ntbtkrJ3UWLRMp&s",
            $"https://img.pngio.com/web-development-software-development-web-design-web-application-software-development-png-728_633.jpg",
            $"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjUuzIu1_E-RBGAnRX805LBW73AnElCcb-Hc6pBz36_DkzNh_k&s",
            $"https://www.thebalancecareers.com/thmb/immznM5HoFhDJs4mlybGxsp6SRw=/950x0/top-soft-skills-for-customer-service-jobs-2063746_v2-5bd0882b46e0fb0026edd456.png",
            $"https://www.bbva.com/wp-content/uploads/en/2017/07/body-image-Why-Bankers-think-like-Designers-now-1024x477.jpg",
            $"https://cdn.edarabia.com/wp-content/uploads/2019/12/competency-based-management-training-295364.jpg",
        };
    }
}
