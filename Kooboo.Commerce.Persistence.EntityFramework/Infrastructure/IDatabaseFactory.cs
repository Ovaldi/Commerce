﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Persistence.EntityFramework.Infrastructure
{
    public interface IDatabaseFactory
    {
        CommerceDbContext Get();
    }
}
