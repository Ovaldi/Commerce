using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Kooboo.Commerce.Persistence.Infrastructure.EntityFramework
{
    [Dependency(typeof(IDatabaseFactory),ComponentLifeStyle.InRequestScope)]
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        private CommerceDbContext _dbContext;
        public CommerceDbContext Get()
        {
            if (this._dbContext != null)
            {
                return this._dbContext;
            }
            else
            {
                string connStr = ConfigurationManager.ConnectionStrings["Commerce"].ConnectionString;
                _dbContext = new CommerceDbContext(connStr);
                _dbContext.Database.CreateIfNotExists();
                return this._dbContext;
            }
        }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
