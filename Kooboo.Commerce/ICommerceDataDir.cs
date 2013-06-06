using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce
{
    public interface ICommerceDataDir
    {
        string DataVirtualFolder
        {
            get;
        }

        string DataPhysicalFolder
        {
            get;
        }
        /*
        string GetDatabaseFilePhysicalFolder(string commerceName);
        string GetImageFilePhysicalFolder(string commerceName);
        string GetSettingFilePhysicalFolder(string commerceName);*/
    }
}
