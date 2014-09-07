namespace Bookstore.Data
{
    using System.Data.Entity;

    using Bookstore.Model;

    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            : base("BookstoreConnection")
        {
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}