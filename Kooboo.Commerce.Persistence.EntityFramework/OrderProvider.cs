using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Orders;
using System.Data;
using System.Linq.Expressions;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(IOrderProvider))]
    public class OrderProvider :ProviderBase, IOrderProvider
    {      
        public OrderProvider(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {

        }

        public Order Get(Expression<Func<Order, bool>> where)
        {
            return this.DbContext.Orders.Where(where).FirstOrDefault();
        }

        public IQueryable<Order> GetMany(Expression<Func<Order, bool>> where)
        {
            return this.DbContext.Orders.Where(where);
        }

        public void Add(Order entity)
        {
            this.DbContext.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            this.DbContext.Orders.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Order entity)
        {
            var old = this.DbContext.Orders.FirstOrDefault(it => it.Id == entity.Id);
            this.DbContext.Orders.Remove(old);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Order, bool>> where)
        {
            var lst = this.DbContext.Orders.Where(where).AsEnumerable();
            foreach (var obj in lst)
            {
                this.DbContext.Orders.Remove(obj);
            }
        }

        public IQueryable<Order> CreateQuery()
        {
            return this.DbContext.Orders.AsQueryable();
        }

        public Order QueryById(int id)
        {
            return this.DbContext.Orders.FirstOrDefault(it => it.Id == id);
        }
    }
}
