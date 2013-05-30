using Kooboo.Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Persistence
{
    public interface ICommerceSettingProvider
    {
        CommerceSetting CreateSetting();

        IEnumerable<CommerceSetting> GetAll();
        CommerceSetting GetByName(string name);
        void Add(CommerceSetting setting);
        void Update(CommerceSetting setting);
        void Delete(CommerceSetting setting);
    }
}
