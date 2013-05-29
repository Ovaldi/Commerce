using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using Kooboo.Commerce.Persistence;
using Kooboo.Web.Mvc.Paging;
using Kooboo.CMS.Common.Runtime.Dependency;

namespace Kooboo.Commerce.Services.Catalog
{
    [Dependency(typeof(IBrandService),ComponentLifeStyle.InRequestScope)]
    public class BrandService:IBrandService
    {
        private IBrandProvider _provider;
        private IUnitOfWork _unitOfWork;

        public BrandService(IBrandProvider provider, IUnitOfWork unitOfWork)
        {
            this._provider = provider;
            this._unitOfWork = unitOfWork;
        }
            
        public Brand ById(int id)
        {
            return this._provider.ById(id);
        }

        public Brand Get(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this._provider.Get(where);
        }

        public void Add(Brand entity)
        {
            this._provider.Add(entity);
            this._unitOfWork.Commit();
        }

        public void Update(Brand entity)
        {
            this._provider.Update(entity);
            this._unitOfWork.Commit();
        }

        public void Delete(int[] ids)
        {
            this._provider.All
                .Where(it => ids.Contains(it.Id))
                .ForEach((it, index) =>
                {
                    it.Deleted = true;
                });
            this._unitOfWork.Commit();
        }

        public IPagedList<Brand> Search(string search, int? page, int? pageSize)
        {
            PagedList<Brand> lst = null;

            IQueryable<Brand> query = this._provider.All.Where(it => it.Deleted == false);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(it => it.Name.Contains(search));
            }

            lst = query.OrderBy(it => it.Id).ToPagedList(page ?? 1, pageSize ?? 50);

            return lst;
        }
    }
}
