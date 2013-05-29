using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Orders;
using Kooboo.Commerce.Persistence;

namespace Kooboo.Commerce.Services.Orders
{
    public class OrderService:IOrderService
    {
        private IOrderProvider _provider;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderProvider provider,IUnitOfWork unitOfWork)
        {
            this._provider = provider;
            this._unitOfWork = unitOfWork;
        }

        public Order ById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(System.Linq.Expressions.Expression<Func<Order, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int[] ids)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Order> Search(string search, int? page, int? pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
