using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OpencvMe.Repository.Base
{
    public interface IRepositoryBase <T>
    {
        T Create(T entity);
        bool CreateRange(List<T> entity);
        T Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
