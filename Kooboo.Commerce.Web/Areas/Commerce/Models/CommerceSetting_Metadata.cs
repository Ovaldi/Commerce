using Kooboo.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kooboo.Commerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Kooboo.Commerce.Web.Areas.Commerce.Models
{
    [MetadataFor(typeof(CommerceSetting))]
    public class CommerceSetting_Metadata
    {
        [Required]
        public string Name
        {
            get;
            set;
        }

        [StringLength(100)]
        public string ConnectionString
        {
            get;
            set;
        }
    }
}