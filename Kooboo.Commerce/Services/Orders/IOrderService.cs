using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Orders;
using System.Linq.Expressions;

namespace Kooboo.Commerce.Services.Orders
{
    public interface IOrderService
    {
        Order ById(int id);

        Order Get(Expression<Func<Order, bool>> where);

        void Add(Order entity);

        void Update(Order entity);

        void Delete(int[] ids);

        IPagedList<Order> Search(string search, int? page, int? pageSize);

    }
}
