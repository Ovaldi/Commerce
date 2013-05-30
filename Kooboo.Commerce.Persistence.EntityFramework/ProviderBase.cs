using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    public abstract class ProviderBase
    {
        private IDatabaseFactory _databaseFactory;
        private CommerceDbContext _dbContext;
        protected CommerceDbContext DbContext
        {
            get
            {
                return this._dbContext??(this._dbContext=this._databaseFactory.Get());
            }
        }

        public ProviderBase(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }
    }
}
