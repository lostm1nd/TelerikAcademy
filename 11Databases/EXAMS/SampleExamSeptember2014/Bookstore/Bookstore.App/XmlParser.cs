namespace Bookstore.App
{
    using Bookstore.App.Contracts;
    using Bookstore.Data;

    public abstract class XmlParser : IXmlParser
    {
        public XmlParser(BookstoreDbContext context, ILogger logger)
        {
            this.BookstoreDb = context;
            this.Logger = logger;
        }

        protected BookstoreDbContext BookstoreDb { get; private set; }

        protected ILogger Logger { get; private set; }

        public abstract void Parse(string uri);
    }
}