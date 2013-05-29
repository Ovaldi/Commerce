using Kooboo.CMS.Common.Persistence.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models.Customers
{
    public class Customer:IEntity
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
