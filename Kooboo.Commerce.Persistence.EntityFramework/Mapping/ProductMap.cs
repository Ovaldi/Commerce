using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using System.Data.Entity.ModelConfiguration;

namespace Kooboo.Commerce.Persistence.EntityFramework.Mapping
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.HasKey(it => it.Id);
        }
    }
}
