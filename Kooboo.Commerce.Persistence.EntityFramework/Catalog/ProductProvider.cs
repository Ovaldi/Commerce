using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;
using Kooboo.Commerce.Persistence.Catalog;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    public class ProductProvider:ProviderBase,IProductProvider
    {

        public ProductProvider(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Product Get(System.Linq.Expressions.Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetMany(System.Linq.Expressions.Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Product> CreateQuery()
        {
            return this.DbContext.Products.AsQueryable();
        }

        public Product QueryById(int id)
        {
            return this.DbContext.Products.FirstOrDefault(it => it.Id == id);
        }
    }
}
