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

        public Brand ById(int id)
        {
            return this.DbContext.Brands.FirstOrDefault(it => it.Id == id);
        }

        public Brand Get(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.FirstOrDefault(where);
        }

        public IQueryable<Brand> All
        {
            get
            {
                return this.DbContext.Brands.AsQueryable();
            }
        }

        public IQueryable<Brand> GetMany(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.Where(where);
        }

        public void Add(Brand entity)
        {
            this.DbContext.Brands.Add(entity);
        }

        public void Update(Brand entity)
        {
            this.DbContext.Brands.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Brand entity)
        {
            var old = this.DbContext.Brands.FirstOrDefault(it => it.Id == entity.Id);
            this.DbContext.Brands.Remove(old);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            this.DbContext.Brands.Where(where).ForEach((it, index) =>
            {
                this.DbContext.Brands.Remove(it);
            });
        }
    }
}
