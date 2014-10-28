using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Book FormViewDetails_GetItem([QueryString]int? bookId)
        {
            if (bookId == null)
            {
                Response.Redirect("~/Default");
            }

            using (LibraryDbContext db = new LibraryDbContext())
            {
                return db.Books.Find(bookId);
            }
        }
    }
}