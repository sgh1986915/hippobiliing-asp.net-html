using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Data.EntityFramework
{
    public class EfRepository:IRepository
    {
        private readonly IProvider<DbContext> _dbContextProvider;
        protected virtual DbContext DbContext { get { return _dbContextProvider.Get(); } }

        public EfRepository(IProvider<DbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return DbContext.Set<T>();
        }

        public T Get<T>(Guid id) where T : Entity
        {
            return DbContext.Set<T>().Find(id);
        }

        public T Create<T>(T entity) where T : Entity
        {
            var result = DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
            return result;
        }

        public IEnumerable<T> CreateRange<T>(IEnumerable<T> entities) where T : Entity
        {
           var results= DbContext.Set<T>().AddRange(entities);
           DbContext.SaveChanges();
           return results;
        }

        public void Update<T>(T entity) where T : Entity
        {
            var entry = DbContext.Entry(entity);
            DbContext.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete<T>(Guid id) where T : Entity
        {
            Delete(Get<T>(id));
        }

        public void Delete<T>(T entity) where T : Entity
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : Entity
        {
            var enumerable  = entities as T[] ?? entities.ToArray();
            if (entities != null && enumerable.Any())
            {
                for (int i = enumerable.Count() - 1; i >= 0; i--)
                {
                    DbContext.Set<T>().Remove(enumerable.ElementAt(i));
                }
                DbContext.SaveChanges();
            }
        }


        public void UpdateRange<T>(IEnumerable<T> entities) where T : Entity
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            if (entities != null && enumerable.Any())
            {
                for (int i = enumerable.Count() - 1; i >= 0; i--)
                {
                    var entry = DbContext.Entry(enumerable.ElementAt(i));
                    DbContext.Set<T>().Attach(enumerable.ElementAt(i));
                    entry.State = EntityState.Modified;
                }
                DbContext.SaveChanges();
            }
        }


      
    }
}
