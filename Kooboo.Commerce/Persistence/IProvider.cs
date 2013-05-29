using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kooboo.Commerce.Persistence
{
    public interface IProvider<T>
        where T:class
    {
        T ById(int id);

        T Get(Expression<Func<T, bool>> where);

        IQueryable<T> All { get; }

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);
    }
}
