using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models;
using Kooboo.Commerce.Persistence;

namespace Kooboo.Commerce.Services
{
    [Dependency(typeof(ICommerceService),ComponentLifeStyle.InRequestScope)]
    public class CommerceService:ICommerceService
    {
        private IEnumerable<CommerceSetting> _settingCache;
        private ICommerceSettingProvider _settingProvider;
        public CommerceService(ICommerceSettingProvider settingProvider)
        {
            this._settingProvider = settingProvider;
        }

        public IEnumerable<CommerceSetting> GetAll()
        {
            if (this._settingCache != null)
            {
                return this._settingCache;
            }
            else
            {
                return this._settingProvider.GetAll();
            }
        }

        public CommerceSetting GetByName(string name)
        {
            return this._settingProvider.GetByName(name);
        }

        public void Add(CommerceSetting setting)
        {
            this._settingProvider.Add(setting);
            this.ClearCache();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommerceSetting> Search(string search)
        {
            var lst = this.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                lst = lst.Where(it => it.Name.ToLower().Contains(search.ToLower()));
            }
            return lst;
        }

        private void ClearCache()
        {
            this._settingCache = null;
        }
    }
}
