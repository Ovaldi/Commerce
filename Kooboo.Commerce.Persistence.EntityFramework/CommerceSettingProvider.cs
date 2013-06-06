using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Persistence;
using Kooboo.Commerce.Models;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.CMS.Sites.Persistence;
using System.IO;
using Kooboo.Globalization;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(ICommerceSettingProvider))]
    public class CommerceSettingProvider:ICommerceSettingProvider
    {
        private ICommerceDataDir _commerceDataDir;
        public CommerceSettingProvider(ICommerceDataDir commerceDataDir)
        {
            this._commerceDataDir = commerceDataDir;
        }

        public virtual IEnumerable<CommerceSetting> GetAll()
        {
            List<CommerceSetting> lst = new List<CommerceSetting>();
            string[] folders = Directory.GetDirectories(this._commerceDataDir.DataPhysicalFolder);
            foreach (string item in folders)
            {
                string settingFilePath = this.GetSettingFilePhysicalPath(item);
                CommerceSetting commerceSetting = Serialization.Deserialize<CommerceSetting>(settingFilePath);
                lst.Add(commerceSetting);
            }
            return lst;
        }

        public CommerceSetting CreateSetting()
        {
            throw new NotImplementedException();
        }

        public CommerceSetting GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(it => it.Name.ToLower().Equals(name.ToLower()));
        }

        public void Add(CommerceSetting setting)
        {
            string commerceFolder = this.GetCommercePhysicalFolder(setting.Name);
            if (!Directory.Exists(commerceFolder))
            {
                //Create folder
                Directory.CreateDirectory(commerceFolder);
                string imagesFolder = this.GetImageFilePhysicalFolder(setting.Name);
                string databaseFolder = this.GetDatabaseFilePhysicalFolder(setting.Name);
                string[] folders = new string[] { imagesFolder,databaseFolder };
                foreach (string path in folders)
                {
                    Directory.CreateDirectory(path);
                }

                //Create database
                if (setting.EnableConnectionString)
                {
                    CommerceDbContext ctx = new CommerceDbContext(setting.ConnectionString);
                    ctx.Database.Create();
                    ctx.Dispose();
                }
                else
                {
                    //SqlCE
                    setting.DatabaseFilePath = this.GetDatabaseFilePhysicalPath(setting.Name);
                    CommerceDbContext ctx = new CommerceDbContext(setting.DatabaseFilePath);
                    ctx.Database.Create();
                    ctx.Dispose();
                }

                //Create file:setting.config
                string settingFilePath = this.GetSettingFilePhysicalPath(setting.Name);
                Serialization.Serialize<CommerceSetting>(setting, settingFilePath);
            }
            else
            {
                string message = string.Format("{0} is already exist.".Localize());
                throw new ArgumentException(message);
            }
        }

        public void Update(CommerceSetting setting)
        {
            throw new NotImplementedException();
        }

        public void Delete(CommerceSetting setting)
        {
            throw new NotImplementedException();
        }

        private string GetCommercePhysicalFolder(string commerceName)
        {
            return Path.Combine(this._commerceDataDir.DataPhysicalFolder, commerceName);
        }

        private string GetDatabaseFilePhysicalFolder(string commerceName)
        {
            return Path.Combine(this._commerceDataDir.DataPhysicalFolder, commerceName, "Data");
        }

        private string GetDatabaseFilePhysicalPath(string commerceName)
        {
            return Path.Combine(GetDatabaseFilePhysicalFolder(commerceName), string.Format("data_{0}.sdf", commerceName));
        }

        private string GetImageFilePhysicalFolder(string commerceName)
        {
            return Path.Combine(this._commerceDataDir.DataPhysicalFolder, commerceName, "Images");
        }

        private string GetSettingFilePhysicalFolder(string commerceName)
        {
            return Path.Combine(this._commerceDataDir.DataPhysicalFolder, commerceName);
        }

        private string GetSettingFilePhysicalPath(string commerceName)
        {
            return Path.Combine(this.GetSettingFilePhysicalFolder(commerceName), "setting.config");
        }
    }
}
