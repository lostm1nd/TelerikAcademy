namespace MusicSystem.Data.Contracts
{
    using MusicSystem.Models;

    public interface IMusicSystemData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        IRepository<Country> Countries { get; }

        void SaveChanges();
    }
}