using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models;
using Kooboo.Commerce.Models.Catalog;
using System.Data;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;
using System.Web;
using System.IO;
using Kooboo.Globalization;
using System.Linq.Expressions;
using Kooboo.Commerce.Persistence.Catalog;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(IBrandProvider),ComponentLifeStyle.InRequestScope)]
    public class BrandProvider:ProviderBase,IBrandProvider
    {
        private IEntityFileProvider _entityFileProvider;
        public BrandProvider(IDatabaseFactory databaseFactory,IEntityFileProvider entityFileProvider)
            :base(databaseFactory)
        {
            this._entityFileProvider = entityFileProvider;
        }

        public Brand Get(Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.FirstOrDefault(where);
        }

        public IQueryable<Brand> GetMany(Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.Where(where);
        }

        public void Delete(Expression<Func<Brand, bool>> where)
        {
            this.DbContext.Brands.Where(where).ForEach((it, index) =>
            {
                this.DbContext.Brands.Remove(it);
            });
        }

        public void Add(Brand obj)
        {
            EntityFileOperationResult result = this._entityFileProvider.SaveAs(obj.LogoFile);
            obj.Logo = result.VirtualPath;
            this.DbContext.Brands.Add(obj);
        }

        public IQueryable<Brand> CreateQuery()
        {
            return this.DbContext.Brands.AsQueryable();
        }

        public void Delete(Brand obj)
        {
            var old = this.DbContext.Brands.FirstOrDefault(it => it.Id == obj.Id);
            old.Deleted = true;
        }

        public Brand QueryById(int id)
        {
            return this.DbContext.Brands.FirstOrDefault(it => it.Id == id);
        }

        public void Update(Brand obj)
        {
            if (obj.LogoFile != null)
            {
                EntityFileOperationResult result = this._entityFileProvider.SaveAs(obj.LogoFile);
                obj.Logo = result.VirtualPath;
            }
            this.DbContext.Brands.Attach(obj);
            this.DbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
