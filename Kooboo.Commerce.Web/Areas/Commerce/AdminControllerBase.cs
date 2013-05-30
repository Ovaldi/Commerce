using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kooboo.Globalization;

namespace Kooboo.Commerce.Web.Areas.Commerce
{
    public class AdminControllerBase : Controller
    {
        /*
        protected string GetLogo()
        {
            if (Request.Files != null && Request.Files.Count > 0)
            {
                string fileName = Request.Files[0].FileName;
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
                    Request.Files[0].SaveAs(path);
                    return CommerceVirtualPath.Instance.GetImagesPath("Tmall", newFileName);
                }
            }
            return null;
        }

        protected void DeleteLogo(string logoPath)
        {
            CommercePhysicalPath.Instance.DeleteFile(logoPath);
        }*/
    }
}
