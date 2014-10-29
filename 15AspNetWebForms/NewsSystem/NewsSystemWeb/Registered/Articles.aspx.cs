using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using NewsSystemWeb.Models;
using NewsSystemWeb.Extensions;

namespace NewsSystemWeb.Registered
{
    public partial class Articles : System.Web.UI.Page
    {
        private NewsDbContext db;

        public Articles()
        {
            this.db = new NewsDbContext();
        }

        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["sortdirection"] == null)
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                {
                    ViewState["sortdirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["sortdirection"] = value;
            }
        }

        public IQueryable<Article> ListViewArticles_GetData([ViewState("orderByExpression")]String expression = null)
        {
            var query = this.db.Articles.Include("Category").Include("Likes");

            if (expression != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        return query.OrderBy(expression);
                    case SortDirection.Descending:
                        return query.OrderByDescending(expression);
                    default:
                        return query.OrderBy(expression);
                }
            }

            return query.OrderBy(a => a.ArticleId);
        }

        public IQueryable<Category> DdlEditCategory_GetData()
        {
            return this.db.Categories;
        }

        public void ListViewArticles_UpdateItem(int articleId)
        {
            Article item = db.Articles.Find(articleId);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", articleId));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }

        protected void ListViewArticles_Sorting(object sender, ListViewSortEventArgs e)
        {
            e.Cancel = true;
            this.ViewState["orderByExpression"] = e.SortExpression;
            this.ListViewArticles.DataBind();
        }
    }
}