using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCidades.Domain.Service
{
    public interface IRepository 
    {
        void Delete<T>(T entity) where T : class;
        IQueryable<T> GetQueryable<T>() where T : class;
        IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> where) where T : class;
        void Insert<T>(T entity) where T : class;
        T Select<T>(Guid id) where T : class;
        T Select<T>(string id) where T : class;
        T Select<T>(int id) where T : class;
        void Update<T>(T entity) where T : class;

    }
}
