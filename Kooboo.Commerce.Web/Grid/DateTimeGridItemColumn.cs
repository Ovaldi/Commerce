using Kooboo.Web.Mvc.Grid2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Web.Grid
{
    public class DateTimeGridItemColumn:GridItemColumn
    {
        public DateTimeGridItemColumn(IGridColumn gridColumn, object dataItem, object propertyValue)
            : base(gridColumn, dataItem, propertyValue)
        {

        }
        public override IHtmlString RenderItemColumn(System.Web.Mvc.ViewContext viewContext)
        {
            string str = "";
            if (PropertyValue != null)
            {
                str = ((DateTime)PropertyValue).ToLocalTime().ToString();
            }
            return new HtmlString(str);
        }
    }
}