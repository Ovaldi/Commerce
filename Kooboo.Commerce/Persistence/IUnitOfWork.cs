using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Persistence
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
