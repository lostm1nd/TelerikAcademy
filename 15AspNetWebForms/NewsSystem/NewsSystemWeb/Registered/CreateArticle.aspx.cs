using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using NewsSystemWeb.Models;

namespace NewsSystemWeb.Registered
{
    public partial class CreateArticle : System.Web.UI.Page
    {
        private NewsDbContext db;

        public CreateArticle()
        {
            this.db = new NewsDbContext();
        }

        public IQueryable<Category> DdlCategories_GetData()
        {
            return this.db.Categories;
        }

        public void FormViewArticle_InsertItem()
        {
            var item = new Article
            {
                AuthorId = User.Identity.GetUserId(),
                DateCreated = DateTime.Now
            };

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.Articles.Add(item);
                this.db.SaveChanges();
            }

            Response.Redirect("~/Registered/Articles");
        }
    }
}