namespace MusicSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        public Country()
        {
            this.Artists = new HashSet<Artist>();
        }

        public int CountryId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}