using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.CMS.Common.Persistence.Relational;
using System.ComponentModel.DataAnnotations;

namespace Kooboo.Commerce.Models.Orders
{
    public class Order:IEntity
    {
        [Key]
        public int Id 
        {
            get;
            set;
        }
    }
}
