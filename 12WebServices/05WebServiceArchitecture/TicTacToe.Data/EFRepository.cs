namespace TicTacToe.Data
{
    using System.Data.Entity;
    using System.Linq;
    using TicTacToe.Data.Contracts;

    public class EFRepository<T> : IRepository<T> where T : class
    {
        private DbContext dbContext;
        private IDbSet<T> set;

        public EFRepository(DbContext databaseContext)
        {
            this.dbContext = databaseContext;
            this.set = databaseContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.ChangeState(entity, EntityState.Deleted);

            return entity;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
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
