namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using MusicSystem.Services.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2002/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                GetAllArtists(client);
                Console.WriteLine("Press enter to proceed");
                Console.ReadLine();

                ArtistServiceModel artist = new ArtistServiceModel
                {
                    Name = "LongJosh",
                    Country = "Neverland",
                    Albums = new List<string> { "Foundation", "The Rcok"}
                };
                AddArtist(client, artist);
                Console.ReadLine();
            }
        }

        private static async void GetAllArtists(HttpClient client)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("Artists/All");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var artists = JsonConvert.DeserializeObject<IEnumerable<ArtistServiceModel>>(json);

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name + " from " + artist.Country + " presents: ");
                    foreach (var album in artist.Albums)
                    {
                        Console.Write(album + " ");

                    }
                    Console.WriteLine();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Cannot access the desired sevice: " + e.Message);
            }
        }

        private static async void AddArtist(HttpClient client, ArtistServiceModel artist)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(artist));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("Artists/Add", body);

            string responsMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responsMessage);
        }
    }
}