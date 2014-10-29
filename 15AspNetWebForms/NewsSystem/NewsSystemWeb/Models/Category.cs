namespace NewsSystemWeb.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int CategoryId { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}