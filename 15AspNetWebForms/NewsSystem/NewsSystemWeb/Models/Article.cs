namespace NewsSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        public Article()
        {
            this.Likes = new HashSet<Like>();
        }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}