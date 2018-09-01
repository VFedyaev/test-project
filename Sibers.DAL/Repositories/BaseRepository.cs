using Sibers.DAL.EF;
using Sibers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.DAL.Repositories
{
    class BaseRepository<T> : IRepository<T> where T : class
    {
        private ApplicationContext Context;
        // Declare generic DbSet<T> (which may be Employees or Projects DbSet from ApplicationContext)
        private DbSet<T> DbSet;

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T Get(Guid? id)
        {
            return DbSet.Find(id);
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T entity = DbSet.Find(id);
            if (entity != null)
                DbSet.Remove(entity);
        }
        
        public async Task<T> GetAsync(Guid? id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
