using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using NewsSystemWeb.Models;

namespace NewsSystemWeb
{
    public partial class _Default : Page
    {
        public IEnumerable<Article> RepeaterMostPopular_GetData()
        {
            NewsDbContext db = new NewsDbContext();
            return db.Articles.OrderByDescending(a => a.Likes.Count()).Include("Category").Take(3);
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            NewsDbContext db = new NewsDbContext();
            return db.Categories.Include("Articles");
        }
    }
}