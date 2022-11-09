using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        private readonly SOSUPowerContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(SOSUPowerContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public T GetByID(object Id)
        {
            return dbSet.Find(Id);
        }

        public virtual async Task<T> GetByIDAsync(object Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}