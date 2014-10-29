using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using NewsSystemWeb.Models;

namespace NewsSystemWeb
{
    public partial class ViewArticle : System.Web.UI.Page
    {
        private NewsDbContext db;

        public ViewArticle()
        {
            this.db = new NewsDbContext();
        }

        public Article FormViewDetails_GetItem([QueryString("id")]int? id)
        {
            if (id == null)
            {
                Response.Redirect("~/");
            }

            return this.db.Articles.Find(id);
        }

        protected void Likes_Upvote(object sender, EventArgs e)
        {
            int articleId = Convert.ToInt32(Request.QueryString["id"]);
            string authorId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(authorId))
            {
                return;
            }

            Article article = this.db.Articles.Find(articleId);

            foreach (var like in article.Likes)
            {
                if (like.AuthorId == authorId)
                {
                    return;
                }
            }

            Like newLike = new Like
            {
                Value = 1,
                AuthorId = User.Identity.GetUserId(),
                ArticleId = articleId
            };

            article.Likes.Add(newLike);
            this.db.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void Likes_Downvote(object sender, EventArgs e)
        {
            int articleId = Convert.ToInt32(Request.QueryString["id"]);
            string authorId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(authorId))
            {
                return;
            }

            Article article = this.db.Articles.Find(articleId);

            foreach (var like in article.Likes)
            {
                if (like.AuthorId == authorId)
                {
                    article.Likes.Remove(like);
                    this.db.Likes.Remove(like);
                    break;
                }
            }

            this.db.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}