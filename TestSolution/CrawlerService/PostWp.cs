using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerService
{
    public class PostWp
    {
        /// <summary>
        /// post_title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// post_content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// post_excerpt
        /// Short description
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        /// The published date of your post.
        /// Format - yyyy/mm/dd
        /// And add a space, then add the time	2018/09/20 10:30
        /// post_category Mention the category name.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// post_category 
        /// Use Comma separator for multiple categories.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// post_tag 
        /// Mention the tag name.Use comma(,) separator to add multiple tags.	Pro plugin, WP plugin, CSV import
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// post_author Add the author name(WordPress User Name) of your post.Smackcoders
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// post_slug Add your post slug.wp-ultimate-csv-importer
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// featured_image
        /// Use media gallery URL or any publicly accessible external URL.
        /// sample: http://www.planwallpaper.com/static/images/434976-happy-valentines-day-timeline-cover.jpg
        /// </summary>
        public string FeaturedImage { get; set; }

        /// <summary>
        /// post_status
        /// post_status Mention the post status. publish / draft / pending / sticky / private / protected.
        /// For private and protected give the password within curly braces { loginpassword }
        ///  publish
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// post_format Mention the value to select the desired post format
        /// 0 - standard
        /// 1 - Aside
        /// 2 - Image
        /// 3 - Video
        /// 4 - Quote
        /// 5 - Link
        /// 6 - Gallery
        /// 7 - Audio
        /// </summary>
        public string Format { get; set; }
    }
}
