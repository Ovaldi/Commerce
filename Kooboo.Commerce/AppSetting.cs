using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Kooboo.Commerce
{
    public class AppSetting
    {
        protected static readonly string CommerceName = "CommerceName";
        public static string CurrentCommerce
        {
            get
            {
                string commerceName = HttpContext.Current.Request[CommerceName];
                if (string.IsNullOrEmpty(commerceName.TrimOrNull()))
                {
                    throw new Exception("Can not find Parameter CommerceName for Url.");
                }
                return HttpContext.Current.Request[CommerceName];
            }
        }
    }
}
