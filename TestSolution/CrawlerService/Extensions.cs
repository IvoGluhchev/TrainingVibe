using Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CrawlerService
{
    public static class Extensions
    {
        public static string CleanUpInnerText(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var sb = new StringBuilder(Regex.Replace(text, @"\s+", " ").Trim());
            sb.Replace("&nbsp;", string.Empty);

            // var result = Regex.Replace(text, @"\s+", " ").Trim();

            return sb.ToString();
        }

        public static PostWp MapToPostWp(this Course course)
        {
            var post = new PostWp();

            try
            {
                post.Title = course.Title;
                post.Category = course.Category;
                post.Content = GetContent(course);
                post.Excerpt = $"{course.Description.Substring(0, 100)}...";
                post.FeaturedImage = !string.IsNullOrEmpty(course.ImageUrl) ? course.ImageUrl : PathConst.NoImage;
                post.Tag = course.Tags;
            }
            catch (Exception)
            {

                throw;
            }

            return post;
        }

        private static string GetContent(Course course)
        {
            var builder = new StringBuilder();
            builder.AppendLine(course.Description.WrapInParagraph());

            if (!string.IsNullOrEmpty(course.StartDate))
            {
                builder.AppendLine(course.StartDate.WrapInParagraph());
            }

            if (!string.IsNullOrEmpty(course.EndDate))
            {
                builder.AppendLine(course.EndDate.WrapInParagraph());
            }

            if (!string.IsNullOrEmpty(course.Duration))
            {
                builder.AppendLine(course.Duration.WrapInParagraph());
            }

            if (!string.IsNullOrEmpty(course.Price))
            {
                builder.AppendLine(course.Price.WrapInParagraph());
            }
            builder.AppendLine($"<div class=\"wp-block-button\"><a class=\"wp-block-button__link has-background has-luminous-vivid-orange-background-color\" href=\"{course.Link}\" target=\"_blank\">Посети</a></div>");
            return builder.ToString();
        }

        private static string WrapInParagraph(this string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }

            return $"<p> {content} </p>";
        }
    }
}
