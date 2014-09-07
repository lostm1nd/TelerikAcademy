namespace Bookstore.App
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    using Bookstore.App.Contracts;
    using Bookstore.Data;
    using Bookstore.Model;

    public class QueriesXmlParser : XmlParser, IXmlParser
    {
        private XElement rootElement;
        private string outputFilePath;

        public QueriesXmlParser(BookstoreDbContext context, ILogger logger, string outputFile)
            : base(context, logger)
        {
            this.rootElement = new XElement("search-results");
            this.outputFilePath = outputFile;
        }

        public override void Parse(string uri)
        {
            this.Logger.LogHeader("Started queries parsing...");

            XDocument doc = XDocument.Load(uri);
            var queryElements = doc.Descendants("query");

            foreach (var queryElement in queryElements)
            {
                this.ParseQuery(queryElement);
                this.Logger.LogLine("Query parsed.");
            }

            this.rootElement.Save(this.outputFilePath);

            this.Logger.LogFooter("Finished queries parsing.");
        }

        private void ParseQuery(XElement queryElement)
        {
            string queryType = queryElement.Attribute("type").Value;
            switch (queryType)
            {
                case "by-period":
                    this.ParseQueryByPeriod(queryElement);
                    break;
                case "by-author":
                    this.ParseQueryByAuthor(queryElement);
                    break;
                default:
                    throw new ArgumentException("Invalid query type: " + queryType);
            }
        }

        private void ParseQueryByPeriod(XElement queryElement)
        {
            DateTime startDate = DateTime.Parse(queryElement.Element("start-date").Value);
            DateTime endDate = DateTime.Parse(queryElement.Element("end-date").Value);

            var query = this.BookstoreDb.Reviews
                .Where(r => r.PublishDate >= startDate && r.PublishDate <= endDate);                

            this.MaterializeQuery(query);
        }

        private void ParseQueryByAuthor(XElement queryElement)
        {
            string authorName = queryElement.Element("author-name").Value;

            var query = this.BookstoreDb.Reviews
                .Where(r => r.Author.Name == authorName);

            this.MaterializeQuery(query);
        }

        private void MaterializeQuery(IQueryable<Review> query)
        {
            var data = query
                .OrderBy(r => r.PublishDate)
                .ThenBy(r => r.Content)
                .Select(r => new
                {
                    ReviewDate = r.PublishDate,
                    Content = r.Content,
                    Book = new
                    {
                        Title = r.Book.Title,
                        Authors = r.Book.Authors.OrderBy(a => a.Name),
                        ISBN = r.Book.ISBN,
                        URL = r.Book.Website
                    }
                }).ToList();

            XElement resultSet = new XElement("result-set");
            foreach (var review in data)
            {
                XElement reviewElement =
                    new XElement("review",
                        GetXElement("date", review.ReviewDate),
                        GetXElement("content", review.Content),
                        new XElement("book",
                            GetXElement("title", review.Book.Title),
                            GetXElement("authors", string.Join(", ", review.Book.Authors.Select(a => a.Name))),
                            GetXElement("isbn", review.Book.ISBN),
                            GetXElement("url", review.Book.URL)));

                resultSet.Add(reviewElement);
            }

            this.rootElement.Add(resultSet);
        }

        private XElement GetXElement(string name, string content)
        {
            if (content == null || content == string.Empty)
            {
                return null;
            }
            else
            {
                return new XElement(name, content);
            }
        }

        private XElement GetXElement(string name, DateTime content)
        {
            if (content == null)
            {
                return null;
            }
            else
            {
                return new XElement(name, content.ToString("d-MMM-yyyy", CultureInfo.InvariantCulture));
            }
        }
    }
}