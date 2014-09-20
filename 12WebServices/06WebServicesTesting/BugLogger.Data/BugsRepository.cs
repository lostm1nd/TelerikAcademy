namespace BugLogger.Data
{
    using System.Data.Entity;
    using System.Linq;

    using BugLogger.Models;

    public class BugsRepository : IRepository<Bug> 
    {
        private DbContext dbContext;
        private IDbSet<Bug> set;

        public BugsRepository(BugLoggerDbContext bugLoggerContext)
        {
            this.dbContext = bugLoggerContext;
            this.set = bugLoggerContext.Set<Bug>();
        }

        public IQueryable<Bug> All()
        {
            return this.set;
        }

        public Bug Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(Bug entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(Bug entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public Bug Delete(Bug entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public Bug Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private void ChangeState(Bug entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
