using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Persistence.Infrastructure;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(IUnitOfWork),ComponentLifeStyle.InRequestScope)]
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private CommerceDbContext _dbContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected CommerceDbContext DbContext
        {
            get
            {
                return this._dbContext ?? (this._dbContext = this._databaseFactory.Get());
            }
        }

        public void Commit()
        {
            this.DbContext.SaveChanges();
        }
    }
}
