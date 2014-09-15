namespace MusicSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using MusicSystem.Data;
    using MusicSystem.Data.Contracts;
    using MusicSystem.Services.Models;
    using MusicSystem.Models;

    public class ArtistsController : ApiController
    {
        private IMusicSystemData data;

        public ArtistsController()
            : this(new MusicSystemData())
        {
        }

        public ArtistsController(IMusicSystemData musicSystemData)
        {
            this.data = musicSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artists.All().Select(ArtistServiceModel.FromArtist);

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.GetArtistById(id);
            var model = ArtistServiceModel.ConvertFromArtist(artist);

            return Ok(model);
        }

        [HttpPost]
        public HttpResponseMessage Add(ArtistServiceModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            Artist newArtist = artistModel.ConvertToArtist(this.data);
            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artistModel.Id = newArtist.ArtistId;

            var response = this.Request.CreateResponse<ArtistServiceModel>(HttpStatusCode.Created, artistModel);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, ArtistServiceModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            var artist = this.GetArtistById(id);

            artist.Name = artistModel.Name;
            artist.DateOfBirth = artistModel.DateOfBirth;

            var country = this.data.Countries.All().FirstOrDefault(c => c.Name == artistModel.Country);
            if (country == null)
            {
                country = new Country
                {
                    Name = artistModel.Country
                };
            }

            artist.Country = country;

            if (artistModel.Albums.Count > 0)
            {
                artist.Albums.Clear();
                foreach (var albumName in artistModel.Albums)
                {
                    artist.Albums.Add(new Album
                    {
                        Name = albumName
                    });
                }
            }

            if (artistModel.Songs.Count > 0)
            {
                artist.Songs.Clear();
                foreach (var songName in artistModel.Songs)
                {
                    artist.Songs.Add(new Song
                    {
                        Name = songName
                    });
                }
            }

            this.data.Artists.Add(artist);
            this.data.SaveChanges();

            artistModel.Id = artist.ArtistId;

            var response = this.Request.CreateResponse<ArtistServiceModel>(HttpStatusCode.OK, artistModel);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var artist = this.GetArtistById(id);

            this.data.Artists.Delete(artist);

            var model = ArtistServiceModel.ConvertFromArtist(artist);

            var response = this.Request.CreateResponse(HttpStatusCode.OK, model);
            return response;
        }

        private Artist GetArtistById(int id)
        {
            var artist = this.data.Artists.All().FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                throw new HttpRequestException("Invalid artist id: " + id);
            }

            return artist;
        }
    }
}