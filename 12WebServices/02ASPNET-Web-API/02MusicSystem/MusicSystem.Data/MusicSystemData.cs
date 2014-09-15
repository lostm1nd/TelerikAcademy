namespace MusicSystem.Data
{
    using System;
    using System.Collections.Generic;

    using MusicSystem.Data.Contracts;
    using MusicSystem.Models;

    public class MusicSystemData : IMusicSystemData
    {
        private IMusicSystemDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public MusicSystemData()
            : this(new MusicSystemDbContext())
        {
        }

        public MusicSystemData(IMusicSystemDbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public IRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
        }

        public IRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }

        public IRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(MusicSystemRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}