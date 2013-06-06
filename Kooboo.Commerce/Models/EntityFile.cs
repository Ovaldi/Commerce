using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Models
{
    public class EntityFile
    {
        public string CommerceName { get; set; }
        public string FileName { get; set; }
        public Stream Data { get; set; }
    }

    public class EntityFileOperationResult
    {
        public string PhysicalPath { get; set; }
        public string VirtualPath { get; set; }
    }
}
