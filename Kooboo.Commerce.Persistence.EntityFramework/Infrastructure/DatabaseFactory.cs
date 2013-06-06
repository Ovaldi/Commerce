using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Kooboo.Commerce.Models;

namespace Kooboo.Commerce.Persistence.EntityFramework.Infrastructure
{
    [Dependency(typeof(IDatabaseFactory),ComponentLifeStyle.InRequestScope)]
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        private CommerceDbContext _dbContext;
        private ICommerceSettingProvider _settingProvider;
        public DatabaseFactory(ICommerceSettingProvider settingProvider)
        {
            this._settingProvider = settingProvider;
        }

        public CommerceDbContext Get()
        {
            if (this._dbContext != null)
            {
                return this._dbContext;
            }
            else
            {
                CommerceSetting setting = this._settingProvider.GetByName(AppSetting.CurrentCommerce);
                string connStr = setting.EnableConnectionString ? setting.ConnectionString : setting.DatabaseFilePath;
                if (string.IsNullOrEmpty(connStr))
                {
                    throw new Exception("Please set up ConnectionString Or DatabaseFilePath for setting.config.");
                }
                this._dbContext = new CommerceDbContext(connStr);
                this._dbContext.Database.CreateIfNotExists();
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
