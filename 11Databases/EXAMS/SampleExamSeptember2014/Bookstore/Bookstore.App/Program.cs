namespace Bookstore.App
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    
    using Bookstore.Data;
    using Bookstore.Data.Migrations;

    internal class Program
    {
        private static void Main()
        {
            BookstoreDbContext dbContext = CreateDatabase();

            BooksXmlParser booksParser = new BooksXmlParser(dbContext, new ConsoleLogger());
            booksParser.Parse("../../../complex-book.xml");

            QueriesXmlParser queriesParser = new QueriesXmlParser(dbContext, new ConsoleLogger(), "../../../reviews-search-results.xml");
            queriesParser.Parse("../../../reviews-queries.xml");
        }

        private static BookstoreDbContext CreateDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BookstoreDbContext>());
            var bookStoreDb = new BookstoreDbContext();
            bookStoreDb.Authors.Any();

            return bookStoreDb;
        }
    }
}