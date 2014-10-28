using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {

        public IEnumerable<Book> RepeaterQuery_GetData([QueryString("q")]string query)
        {
            this.QueryText.Text = query;
            LibraryDbContext db = new LibraryDbContext();
            var books = db.Books.Include("Category").Where(b => b.Author.Contains(query) || b.Title.Contains(query));

            return books;
        }
    }
}