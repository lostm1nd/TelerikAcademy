namespace MusicSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MusicSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MusicSystem.Data.MusicSystemDbContext";
        }

        protected override void Seed(MusicSystemDbContext context)
        {
            this.SeedCountries(context);

            this.SeedArtists(context);
        }

        private void SeedCountries(MusicSystemDbContext context)
        {
            string[] countries = { "Bulgaria", "United Kingdom", "France", "Germany", "Serbia" };

            if (!context.Countries.Any())
            {
                foreach (var contry in countries)
                {
                    context.Countries.Add(new Country
                    {
                        Name = contry
                    });
                }

                context.SaveChanges();
            }
        }
        private void SeedArtists(MusicSystemDbContext context)
        {
            if (!context.Artist.Any())
            {
                var countries = context.Countries.ToList();

                var newfound = new Artist
                {
                    Name = "Newfound",
                    Country = countries.FirstOrDefault(),
                    DateOfBirth = DateTime.Now.AddYears(-22),
                };

                var newfoundAlbum = new Album
                {
                    Name = "Debut"
                };

                for (int i = 1; i < 10; i++)
                {
                    newfoundAlbum.Songs.Add(new Song
                    {
                        Name = "track " + i
                    });
                }

                newfound.Albums.Add(newfoundAlbum);

                context.Artist.Add(newfound);
                context.SaveChanges();
            }
        }
    }
}