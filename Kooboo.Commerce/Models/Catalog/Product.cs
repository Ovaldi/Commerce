using Kooboo.CMS.Common.Persistence.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models.Catalog
{
    public class Product : IEntity
    {
        public int Id
        {
            get;
            set;
        }

        [StringLength(255)]
        public string Name
        {
            get;
            set;
        }

        [StringLength(500)]
        public string Summary
        {
            get;
            set;
        }

        [StringLength(2000)]
        public string Description
        {
            get;
            set;
        }

        public decimal? Weight
        {
            get;
            set;
        }

        public bool Deleted
        {
            get;
            set;
        }

        public bool Published
        {
            get;
            set;
        }

        public PackageSize PackageSize
        {
            get;
            set;
        }

        public int? BrandID
        {
            get;
            set;
        }

        public Brand Brand
        {
            get;
            set;
        }

        public int? ProductTypeID
        {
            get;
            set;
        }

    }
}
