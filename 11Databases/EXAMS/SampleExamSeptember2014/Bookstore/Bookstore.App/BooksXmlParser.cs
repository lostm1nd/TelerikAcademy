namespace Bookstore.App
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Bookstore.App.Contracts;
    using Bookstore.Data;
    using Bookstore.Model;

    public class BooksXmlParser : XmlParser, IXmlParser
    {
        public BooksXmlParser(BookstoreDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        public override void Parse(string uri)
        {
            this.Logger.LogHeader("Started books parsing...");

            XDocument doc = XDocument.Load(uri);
            var booksElements = doc.Descendants("book");

            foreach (var bookElement in booksElements)
            {
                Book currentBook = new Book();

                this.ParseBookTitle(currentBook, bookElement.Element("title"));

                this.ParseBookIsbn(currentBook, bookElement.Element("isbn"));

                this.ParseBookPrice(currentBook, bookElement.Element("price"));

                this.ParseBookWebsite(currentBook, bookElement.Element("web-site"));

                this.ParseBookAuthors(currentBook, bookElement.Element("authors"));

                this.ParseBookReviews(currentBook, bookElement.Element("reviews"));

                this.BookstoreDb.Books.Add(currentBook);
                this.BookstoreDb.SaveChanges();

                this.Logger.LogLine("Book added.");
            }

            this.Logger.LogFooter("Finished books parsing.");
        }

        private void ParseBookTitle(Book currentBook, XElement bookTitleElement)
        {
            if (bookTitleElement == null)
            {
                throw new ArgumentException("Book title cannot be null.");
            }

            currentBook.Title = bookTitleElement.Value;
        }

        private void ParseBookIsbn(Book currentBook, XElement bookIsbnElement)
        {
            if (bookIsbnElement != null)
            {
                string isbn = bookIsbnElement.Value;
                if (this.BookstoreDb.Books.Any(b => b.ISBN == isbn))
                {
                    throw new ArgumentException("Book with ISBN '" + isbn + "' already exists.");
                }

                currentBook.ISBN = isbn;
            }
        }

        private void ParseBookPrice(Book currentBook, XElement bookPriceElement)
        {
            if (bookPriceElement != null)
            {
                currentBook.Price = decimal.Parse(bookPriceElement.Value, CultureInfo.InvariantCulture);
            }
        }

        private void ParseBookWebsite(Book currentBook, XElement bookSiteElement)
        {
            if (bookSiteElement != null)
            {
                currentBook.Website = bookSiteElement.Value;
            }
        }

        private void ParseBookAuthors(Book currentBook, XElement bookAuthorsElement)
        {
            if (bookAuthorsElement != null)
            {
                foreach (var authorElement in bookAuthorsElement.Elements("author"))
                {
                    string authorName = authorElement.Value;

                    Author author = GetAuthor(authorName);

                    currentBook.Authors.Add(author);
                }
            }
        }

        private void ParseBookReviews(Book currentBook, XElement bookReviewsElement)
        {
            if (bookReviewsElement != null)
            {
                foreach (var reviewElement in bookReviewsElement.Elements("review"))
                {
                    var pubDateAttribute = reviewElement.Attribute("date");
                    Review review = new Review
                    {
                        Content = reviewElement.Value,
                        PublishDate = pubDateAttribute == null ? DateTime.Now : DateTime.Parse(pubDateAttribute.Value)
                    };

                    var authorAttribute = reviewElement.Attribute("author");
                    if (authorAttribute != null)
                    {
                        string authorName = authorAttribute.Value;
                        Author author = GetAuthor(authorName);
                        review.Author = author;
                    }

                    currentBook.Reviews.Add(review);
                }
            }
        }

        private Author GetAuthor(string authorName)
        {
            Author author = this.BookstoreDb.Authors.FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }
    }
}