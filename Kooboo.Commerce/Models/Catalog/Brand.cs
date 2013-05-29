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
        public virtual ICollection<Product> Products
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
