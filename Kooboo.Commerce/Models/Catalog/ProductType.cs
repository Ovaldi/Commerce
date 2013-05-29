using Kooboo.CMS.Common.Persistence.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models.Catalog
{
    public class ProductType:IEntity
    {

        public int Id
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SkuAlias
        {
            get;
            set;
        }

        public bool HasSummary
        {
            get;
            set;
        }

        public bool HasDescription
        {
            get;
            set;
        }

        public bool HasWeight
        {
            get;
            set;
        }

        public bool HasPackageSize
        {
            get;
            set;
        }

        public bool Deleted
        {
            get;
            set;
        }

        //TODO:CustomField List

        private ICollection<Product> _products;
        public virtual ICollection<Product> Products
        {
            get
            {
                return this._products ?? (this._products = new List<Product>());
            }
            set
            {
                this._products = value;
            }
        }


    }
}
