using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models;

namespace Kooboo.Commerce.Services
{
    public interface ICommerceService
    {
        IEnumerable<CommerceSetting> GetAll();
        CommerceSetting GetByName(string name);
        void Add(CommerceSetting setting);
        void Delete(string name);
    }
}
