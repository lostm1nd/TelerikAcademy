using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NewsSystemWeb.Models;

namespace NewsSystemWeb.Registered
{
    public partial class Categories : System.Web.UI.Page
    {
        private NewsDbContext db;

        public Categories()
        {
            this.db = new NewsDbContext();
        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            return this.db.Categories;
        }

        public void GridViewCategories_UpdateItem(int categoryId)
        {
            Category item = this.db.Categories.Find(categoryId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", categoryId));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }

        public void GridViewCategories_DeleteItem(int categoryId)
        {
            Category item = this.db.Categories.Find(categoryId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", categoryId));
                return;
            }

            this.db.Categories.Remove(item);
            this.db.SaveChanges();
        }


        public void CreateCategoryFormView_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.Categories.Add(item);
                this.db.SaveChanges();
            }

            this.CreateCategoryPanel.Visible = false;
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void CreateCategoryBtn_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = true;
        }

        protected void CancelCategoryCreate_Click(object sender, EventArgs e)
        {
            this.CreateCategoryPanel.Visible = false;
        }
    }
}