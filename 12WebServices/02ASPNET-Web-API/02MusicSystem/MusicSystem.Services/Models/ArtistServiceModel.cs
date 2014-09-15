namespace MusicSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using MusicSystem.Models;
    using MusicSystem.Data.Contracts;

    public class ArtistServiceModel
    {
        public ArtistServiceModel()
        {
            this.Albums = new List<string>();
            this.Songs = new List<string>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<string> Albums { get; set; }

        public ICollection<string> Songs { get; set; }

        public static Expression<Func<Artist, ArtistServiceModel>> FromArtist
        {
            get
            {
                return a => new ArtistServiceModel
                {
                    Id = a.ArtistId,
                    Name = a.Name,
                    Country = a.Country.Name,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(album => album.Name).ToList(),
                    Songs = a.Songs.Select(song => song.Name).ToList()
                };
            }
        }

        public static ArtistServiceModel ConvertFromArtist(Artist artist)
        {
            ArtistServiceModel model = new ArtistServiceModel
            {
                Id = artist.ArtistId,
                Name = artist.Name,
                Country = artist.Country.Name,
                DateOfBirth = artist.DateOfBirth
            };

            foreach (var album in artist.Albums)
            {
                model.Albums.Add(album.Name);
            }

            foreach (var song in artist.Songs)
            {
                model.Songs.Add(song.Name);
            }

            return model;
        }

        public Artist ConvertToArtist(IMusicSystemData musicSystemData)
        {
            Artist artist = new Artist
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth
            };

            Country country = musicSystemData.Countries.All().FirstOrDefault(c => c.Name == this.Country);
            if (country == null)
            {
                country = new Country
                {
                    Name = this.Country
                };
            }

            artist.Country = country;

            foreach (var albumName in this.Albums)
            {
                artist.Albums.Add(new Album
                {
                    Name = albumName
                });
            }

            foreach (var songName in this.Songs)
            {
                artist.Songs.Add(new Song
                {
                    Name = songName
                });
            }

            return artist;
        }
    }
}