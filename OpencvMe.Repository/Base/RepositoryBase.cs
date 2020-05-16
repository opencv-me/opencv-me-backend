using Microsoft.EntityFrameworkCore;
using OpencvMe.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OpencvMe.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected EfContext _context { get; set; }

        public RepositoryBase(EfContext context)
        {
            _context = context;
        }


        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
           var data = _context.Set<T>().Find(id);
           return Delete(data);
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);

        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }


        public T Update()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }

        public bool CreateRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return true;
        }
    }
}
