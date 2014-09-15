namespace MusicSystem.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;    

    using MusicSystem.Models;

    public interface IMusicSystemDbContext
    {
        IDbSet<Artist> Artist { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}