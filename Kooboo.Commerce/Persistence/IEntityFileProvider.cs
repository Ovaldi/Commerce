using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models;

namespace Kooboo.Commerce.Persistence
{
    public interface IEntityFileProvider
    {
        EntityFileOperationResult SaveAs(EntityFile file);
    }
}
