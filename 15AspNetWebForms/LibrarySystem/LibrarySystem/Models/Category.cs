namespace LibrarySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}