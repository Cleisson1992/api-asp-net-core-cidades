using ApiCidades.Domain.Service;
using ApiCidades.Infra.DataAccess;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCidades.Infra.Service
{
    public class Repository : IRepository
    {
        private readonly ApiCidadesContext _context;

        public Repository(ApiCidadesContext context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> where) where T : class
        {
            return _context.Set<T>().Where(where);
        }

        public void Insert<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public T Select<T>(Guid id) where T : class
        {
            return _context.Find<T>(id);
        }

        public T Select<T>(string id) where T : class
        {
            return _context.Find<T>(id);
        }

        public T Select<T>(int id) where T : class
        {
            return _context.Find<T>(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
