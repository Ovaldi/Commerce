using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kooboo.CMS.Common.Persistence.Relational;

namespace Kooboo.Commerce.Persistence
{
    public interface IProvider<T>:Kooboo.CMS.Common.Persistence.Relational.IProvider<T>
        where T:class
    {
        T Get(Expression<Func<T, bool>> where);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Delete(Expression<Func<T, bool>> where);
         
    }
}
