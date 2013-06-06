using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Kooboo;
using Kooboo.Commerce.Models;
using System.Web.Hosting;
using Kooboo.CMS.Common.Runtime.Dependency;

namespace Kooboo.Commerce.Persistence
{
    [Dependency(typeof(IEntityFileProvider),ComponentLifeStyle.Singleton)]
    public class EntityFileProvider:IEntityFileProvider
    {
        private ICommerceDataDir _commerceDataDir;
        public EntityFileProvider(ICommerceDataDir commerceDataDir)
        {
            this._commerceDataDir = commerceDataDir;
        }

        public virtual EntityFileOperationResult SaveAs(EntityFile file)
        {
            EntityFileOperationResult result = new EntityFileOperationResult();

            string virtualPath = Path.Combine(this._commerceDataDir.DataVirtualFolder, file.CommerceName, "Images", file.FileName);
            string physicalPath = Kooboo.Web.Url.UrlUtility.MapPath(virtualPath);

            byte[] data=new byte[file.Data.Length];
            file.Data.Read(data, 0, data.Length);
            
            FileStream fs = new FileStream(physicalPath, FileMode.Create);
            try
            {
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                fs.Close();
                throw ex;
            }

            result.PhysicalPath = physicalPath;
            result.VirtualPath = virtualPath;
            return result;
        }
    }
}
