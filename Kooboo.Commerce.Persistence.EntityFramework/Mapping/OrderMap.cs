using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Orders;
using System.Data.Entity.ModelConfiguration;

namespace Kooboo.Commerce.Persistence.EntityFramework.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(it => it.Id);
        }
    }
}
