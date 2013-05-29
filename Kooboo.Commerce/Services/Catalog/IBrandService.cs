using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using System.Linq.Expressions;

namespace Kooboo.Commerce.Services.Catalog
{
    public interface IBrandService
    {
        Brand ById(int id);

        Brand Get(Expression<Func<Brand, bool>> where);

        void Add(Brand entity);

        void Update(Brand entity);

        void Delete(int[] ids);

        IPagedList<Brand> Search(string search, int? page, int? pageSize);

    }
}
