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
        private List<CommerceSetting> CacheSettings;
        public virtual IEnumerable<CommerceSetting> GetAll()
        {
            if (this.CacheSettings == null)
            {
                List<CommerceSetting> lst = new List<CommerceSetting>();
                string[] folders = Directory.GetDirectories(CommercePhysicalPath.Instance.FileFolder);
                foreach (string item in folders)
                {
                    string settingFilePath = CommercePhysicalPath.Instance.GetSettingFilePath(item);
                    CommerceSetting commerceSetting = Serialization.Deserialize<CommerceSetting>(settingFilePath);
                    lst.Add(commerceSetting);
                }
                this.CacheSettings = lst;
            }

            return this.CacheSettings;
        }

        public CommerceSetting CreateSetting()
        {
            throw new NotImplementedException();
        }

        public CommerceSetting GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(CommerceSetting setting)
        {
            string commerceFolder = CommercePhysicalPath.Instance.GetCommerceFolder(setting.Name);
            if (!Directory.Exists(commerceFolder))
            {
                Directory.CreateDirectory(commerceFolder);
                string imagesFolder = CommercePhysicalPath.Instance.GetImagesFolder(setting.Name);
                string[] folders = new string[] { imagesFolder };
                foreach (string path in folders)
                {
                    Directory.CreateDirectory(path);
                }

                string settingFilePath = CommercePhysicalPath.Instance.GetSettingFilePath(setting.Name);
                Serialization.Serialize<CommerceSetting>(setting, settingFilePath);

                if (setting.EnableConnectionString)
                {
                    CommerceDbContext ctx = new CommerceDbContext(setting.ConnectionString);
                    ctx.Database.Create();
                    ctx.Dispose();
                }
                else
                {
                    //SqlCE
                    string databaseFilePath = CommercePhysicalPath.Instance.GetDatabaseFilePath(setting.Name);
                    CommerceDbContext ctx = new CommerceDbContext(databaseFilePath);
                    ctx.Database.Create();
                    ctx.Dispose();
                }
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
    }
}
