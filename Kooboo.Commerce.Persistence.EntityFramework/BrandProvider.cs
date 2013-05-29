using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using System.Data;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Persistence.Infrastructure;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(IBrandProvider),ComponentLifeStyle.InRequestScope)]
    public class BrandProvider:ProviderBase,IBrandProvider
    {
        public BrandProvider(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }

        public Brand Get(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.FirstOrDefault(where);
        }

        public IQueryable<Brand> GetMany(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.Where(where);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            this.DbContext.Brands.Where(where).ForEach((it, index) =>
            {
                this.DbContext.Brands.Remove(it);
            });
        }

        public void Add(Brand obj)
        {
            this.DbContext.Brands.Add(obj);
        }

        public IQueryable<Brand> CreateQuery()
        {
            return this.DbContext.Brands.AsQueryable();
        }

        public void Delete(Brand obj)
        {
            var old = this.DbContext.Brands.FirstOrDefault(it => it.Id == obj.Id);
            this.DbContext.Brands.Remove(old);
        }

        public Brand QueryById(int id)
        {
            return this.DbContext.Brands.FirstOrDefault(it => it.Id == id);
        }

        public void Update(Brand obj)
        {
            this.DbContext.Brands.Attach(obj);
            this.DbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
