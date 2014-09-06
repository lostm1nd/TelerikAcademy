namespace ForumRssFeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections;
    using System.Text;

    class Program
    {
        private const string TelerikAcademyForumsRss = @"http://forums.academy.telerik.com/feed/qa.rss";

        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(TelerikAcademyForumsRss);

            string serializedFeed = JsonConvert.SerializeXmlNode(doc.DocumentElement, Newtonsoft.Json.Formatting.Indented);

            // File.WriteAllText("../../../feed.txt", serializedFeed);

            JObject jFeed = JObject.Parse(serializedFeed);
            var titles = jFeed["rss"]["channel"]["item"].Select(item => item["title"]);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine(new String('=', 50));

            Feed deserializedFeed = JsonConvert.DeserializeObject<Feed>(serializedFeed);

            CreateHtmlPage(deserializedFeed);

            Console.WriteLine("Html page is in the project directory");
        }

        private static void CreateHtmlPage(Feed deserializedFeed)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"UTF-8\"/>");
            sb.AppendLine("<title>Telerik Academy Feed</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<ul>");

            foreach (var item in deserializedFeed.Rss.Channel.Item)
            {
                sb.AppendLine("<li><a href=\"" + item.Link + "\">" + item.Title + "</a></li>");
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText("../../../feed.html", sb.ToString());
        }
    }
}