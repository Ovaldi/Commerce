using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models
{
    public class CommerceSetting
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual bool EnableConnectionString
        {
            get;
            set;
        }

        public virtual string ConnectionString 
        { 
            get;
            set;
        }

        public virtual string DatabaseFilePath
        {
            get;
            set;
        }

    }
}
