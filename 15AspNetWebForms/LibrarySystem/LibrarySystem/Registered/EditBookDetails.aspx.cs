using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;
using System.Web.ModelBinding;

namespace LibrarySystem.Registered
{
    public partial class EditBookDetails : System.Web.UI.Page
    {
        private LibraryDbContext db;

        public EditBookDetails()
        {
            this.db = new LibraryDbContext();
        }

        public Book FormViewBook_GetItem([QueryString("bookId")]int id)
        {
            return this.db.Books.Find(id);
        }

        public IQueryable<Category> DDLCategories_GetData()
        {
            return this.db.Categories;
        }

        public void FormViewBook_UpdateItem(int bookId)
        {
            Book item = this.db.Books.Find(bookId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", bookId));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }

            this.Response.Redirect("~/Registered/Books");
        }

        protected void CalcelCategoryCreate_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Registered/Books");
        }
    }
}