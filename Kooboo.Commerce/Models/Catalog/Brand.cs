using Kooboo.CMS.Common.Persistence.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models.Catalog
{
    public class Brand:IEntity
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required,StringLength(50)]
        public string Name
        {
            get;
            set;
        }

        [StringLength(500)]
        public string Logo
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool Deleted
        {
            get;
            set;
        }

        private ICollection<Product> _products;
        public ICollection<Product> Products
        {
            get
            {
                return _products ?? (_products = new List<Product>());
            }
            protected set
            {
                _products = value;
            }
        }
    }
}
