namespace MusicSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int SongId { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}