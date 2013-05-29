using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using Kooboo.ComponentModel;
using Kooboo.Web.Mvc.Grid2.Design;
using Kooboo.Commerce.Web.Grid;

namespace Kooboo.Commerce.Web.Areas.Models.Catalog
{
    [MetadataFor(typeof(Brand))]
    [Grid(Checkable = true, IdProperty = "Id")]
    public class Brand_Metadata
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [GridColumn(GridItemColumnType = typeof(EditGridActionItemColumn))]
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

        [GridColumn]
        [StringLength(2000)]
        [UIHint("Tinymce")]
        public string Description
        {
            get;
            set;
        }
    }
}
