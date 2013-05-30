using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Persistence.EntityFramework.Infrastructure
{
    public class CommerceVirtualPath
    {
        public static readonly CommerceVirtualPath Instance = new CommerceVirtualPath();
        private CommerceVirtualPath() { }

        public string DatabaseFolder
        {
            get
            {
                return "~/App_Data/Database";
            }
        }

        public string FileFolder
        {
            get
            {
                return "~/CMS_data/Commerces";
            }
        }

        public string GetDatabaseFilePath(string commerceName)
        {
            return Path.Combine(this.DatabaseFolder, string.Format("{0}.sdf", commerceName));
        }

        public string GetImagesFolder(string commerceName)
        {
            return Path.Combine(this.FileFolder, commerceName, "Images");
        }

        public string GetImagesPath(string commerceName, string fileName)
        {
            return Path.Combine(this.GetImagesFolder(commerceName), fileName);
        }

        public string GetCommerceFolder(string commerceName)
        {
            return Path.Combine(this.FileFolder, commerceName);
        }

        public string GetSettingFilePath(string commerceName)
        {
            return Path.Combine(this.GetCommerceFolder(commerceName), "setting.config");
        }
    }
}