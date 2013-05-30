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
        private ICommerceSettingProvider _settingProvider;
        public CommerceService(ICommerceSettingProvider settingProvider)
        {
            this._settingProvider = settingProvider;
        }

        public IEnumerable<CommerceSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommerceSetting GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(CommerceSetting setting)
        {
            this._settingProvider.Add(setting);
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
