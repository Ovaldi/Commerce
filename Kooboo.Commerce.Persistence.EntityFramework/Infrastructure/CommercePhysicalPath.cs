using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;

namespace Kooboo.Commerce.Persistence.EntityFramework.Infrastructure
{
    public class CommercePhysicalPath
    {
        public readonly static CommercePhysicalPath Instance = new CommercePhysicalPath();

        public string DatabaseFolder
        {
            get
            {
                return MapPath(CommerceVirtualPath.Instance.DatabaseFolder);
            }
        }

        public string FileFolder
        {
            get
            {
                return MapPath(CommerceVirtualPath.Instance.FileFolder);
            }
        }
        private CommercePhysicalPath()
        {
            string[] folders = new string[] { this.DatabaseFolder, this.FileFolder };
            foreach (var path in folders)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        public string GetDatabaseFilePath(string commerceName)
        {
            return this.MapPath(CommerceVirtualPath.Instance.GetDatabaseFilePath(commerceName));
        }

        public string GetImagesFolder(string commerceName)
        {
            return this.MapPath(CommerceVirtualPath.Instance.GetImagesFolder(commerceName));
        }

        public string GetImagesPath(string commerceName, string fileName)
        {
            return this.MapPath(CommerceVirtualPath.Instance.GetImagesPath(commerceName, fileName));
        }

        public string GetCommerceFolder(string commerceName)
        {
            return this.MapPath(CommerceVirtualPath.Instance.GetCommerceFolder(commerceName));
        }

        public string GetSettingFilePath(string commerceName)
        {
            return this.MapPath(CommerceVirtualPath.Instance.GetSettingFilePath(commerceName));
        }

        public void DeleteFile(string filePath)
        {
            filePath = this.MapPath(filePath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string MapPath(string path)
        {
            string returnPath = null;
            if (HostingEnvironment.IsHosted)
            {
                returnPath = HostingEnvironment.MapPath(path);
            }
            else
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
                returnPath = Path.Combine(baseDirectory, path);
            }
            return returnPath;
        }
    }
}