using Kooboo.CMS.Common.Persistence.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models.Catalog
{
    public class Category:IEntity
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

        [StringLength(2000)]
        public string Description
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

        public bool Deleted
        {
            get;
            set;
        }

        public int? ParentID
        {
            get;
            set;
        }

        public virtual Category Parent
        {
            get;
            set;
        }

        private ICollection<Category> _children;
        public virtual ICollection<Category> Children
        {
            get
            {
                return _children ?? (_children = new List<Category>());
            }
            protected set
            {
                _children = value;
            }
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
