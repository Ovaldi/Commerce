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
            return this._provider.QueryById(id);
        }

        public Order Get(System.Linq.Expressions.Expression<Func<Order, bool>> where)
        {
            return this._provider.Get(where);
        }

        public void Add(Order entity)
        {
            this._provider.Add(entity);
            this._unitOfWork.Commit();
        }

        public void Update(Order entity)
        {
            this._provider.Update(entity);
            this._unitOfWork.Commit();
        }

        public void Delete(int[] ids)
        {
            this._provider.Delete(it => ids.Contains(it.Id));
            this._unitOfWork.Commit();
        }

        public IPagedList<Order> Search(string search, int? page, int? pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
