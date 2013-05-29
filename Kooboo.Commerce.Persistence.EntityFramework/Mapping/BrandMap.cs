using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Kooboo.Commerce.Models.Catalog;

namespace Kooboo.Commerce.Persistence.EntityFramework.Mapping
{
    public class BrandMap:EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
            this.HasKey(it => it.Id);
            this.Property(it => it.Name).IsRequired().HasMaxLength(50);
            this.Property(it => it.Logo).HasMaxLength(500);
            this.Property(it => it.Description).HasMaxLength(2000);
        }
    }
}
