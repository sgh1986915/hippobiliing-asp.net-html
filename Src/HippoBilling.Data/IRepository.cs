using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Data
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : Entity;
        T Get<T>(Guid id) where T : Entity;
        T Create<T>(T entity) where T : Entity;
        IEnumerable<T> CreateRange<T>(IEnumerable<T> entities) where T : Entity; 
        void Update<T>(T entity) where T : Entity;

        void UpdateRange<T>(IEnumerable<T> entities) where T : Entity;
        void Delete<T>(Guid id) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void DeleteRange<T>(IEnumerable<T> entities) where T : Entity;

    }
}
