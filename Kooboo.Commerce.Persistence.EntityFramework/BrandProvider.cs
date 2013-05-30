using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Models.Catalog;
using System.Data;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Persistence.EntityFramework.Infrastructure;
using System.Web;
using System.IO;
using Kooboo.Globalization;

namespace Kooboo.Commerce.Persistence.EntityFramework
{
    [Dependency(typeof(IBrandProvider),ComponentLifeStyle.InRequestScope)]
    public class BrandProvider:ProviderBase,IBrandProvider
    {
        public BrandProvider(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }

        public Brand Get(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.FirstOrDefault(where);
        }

        public IQueryable<Brand> GetMany(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            return this.DbContext.Brands.Where(where);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Brand, bool>> where)
        {
            this.DbContext.Brands.Where(where).ForEach((it, index) =>
            {
                this.DbContext.Brands.Remove(it);
            });
        }

        public void Add(Brand obj)
        {
            obj.Logo = this.SaveLogoFile(obj.HttpPostedFileBase);
            this.DbContext.Brands.Add(obj);
        }

        public IQueryable<Brand> CreateQuery()
        {
            return this.DbContext.Brands.AsQueryable();
        }

        public void Delete(Brand obj)
        {
            var old = this.DbContext.Brands.FirstOrDefault(it => it.Id == obj.Id);
            old.Deleted = true;
        }

        public Brand QueryById(int id)
        {
            return this.DbContext.Brands.FirstOrDefault(it => it.Id == id);
        }

        public void Update(Brand obj)
        {
            string newLogo = this.SaveLogoFile(obj.HttpPostedFileBase);
            if (!string.IsNullOrEmpty(newLogo)&&!string.IsNullOrEmpty(obj.Logo))
            {
                this.DeleteLogoFile(obj.Logo);
                obj.Logo = newLogo;
            }
            this.DbContext.Brands.Attach(obj);
            this.DbContext.Entry(obj).State = EntityState.Modified;
        }

        /*****************************************************************************/
        private string SaveLogoFile(HttpPostedFileBase filebase)
        {
            if (filebase != null)
            {
                string fileName = filebase.FileName;
                string extension = Path.GetExtension(fileName);
                if (!FileExtensions.ImageArray.Contains(extension.ToLower()))
                {
                    string message = "Only enable ".Localize() + FileExtensions.Image;
                    throw new ArgumentException(message);
                }
                else
                {
                    string newFileName = Guid.NewGuid().ToString() + extension;
                    string path = CommercePhysicalPath.Instance.GetImagesPath("Tmall", newFileName);
                    filebase.SaveAs(path);
                    return CommerceVirtualPath.Instance.GetImagesPath("Tmall", newFileName);
                }
            }
            return null;
        }

        private void DeleteLogoFile(string logoPath)
        {
            CommercePhysicalPath.Instance.DeleteFile(logoPath);
        }
    }
}
