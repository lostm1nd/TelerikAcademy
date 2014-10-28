using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;
using System.Web.ModelBinding;

namespace LibrarySystem.Registered
{

    public partial class Books : System.Web.UI.Page
    {
        private LibraryDbContext db;
        public Books()
        {
            db = new LibraryDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> GridViewBooks_GetData()
        {
            return this.db.Books.Include("Category");
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

            this.BookActionsPanel.Visible = false;
        }

        protected void CreateBookBtn_Click(object sender, EventArgs e)
        {
            this.BookActionsPanel.Visible = true;
        }

        public IQueryable<Category> DDLCategories_GetData()
        {
            return this.db.Categories;
        }

        public void FormViewBook_InsertItem()
        {
            var item = new LibrarySystem.Models.Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.Books.Add(item);
                this.db.SaveChanges();
            }
        }

        protected void CalcelCategoryCreate_Click(object sender, EventArgs e)
        {
            this.BookActionsPanel.Visible = false;
        }
    }
}