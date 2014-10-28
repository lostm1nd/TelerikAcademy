using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibrarySystem.Models;

namespace LibrarySystem.Registered
{
    public partial class Categories : System.Web.UI.Page
    {
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> GridViewCategories_GetData()
        {
            LibraryDbContext db = new LibraryDbContext();
            return db.Categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int categoryId)
        {
            LibraryDbContext db = new LibraryDbContext();
            Category item = db.Categories.Find(categoryId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", categoryId));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int categoryId)
        {
            LibraryDbContext db = new LibraryDbContext();
            Category item = db.Categories.Find(categoryId);
            if (item != null)
            {
                db.Categories.Remove(item);
                db.SaveChanges();
            }
        }

        protected void CreateCategoryBtn_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = true;
        }

        public void CreateCategoryFormView_InsertItem()
        {
            LibraryDbContext db = new LibraryDbContext();
            var item = new LibrarySystem.Models.Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.Categories.Add(item);
                db.SaveChanges();
            }

            this.CreateCategoryPanel.Visible = false;
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void CalcelCategoryCreate_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = false;
        }
    }
}