using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kooboo.Web.Url;
using Kooboo.CMS.Common.Runtime.Dependency;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(ICommerceDataDir),ComponentLifeStyle.InRequestScope)]
    public class CommerceDataDir:ICommerceDataDir
    {
        public string DataVirtualFolder
        {
            get 
            {
                return "~/Cms_Data/Commerces";    
            }
        }

        public string DataPhysicalFolder
        {
            get
            {
                return UrlUtility.MapPath(this.DataVirtualFolder);
            }
        }
    }
}
