using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kooboo.Commerce.Services.Catalog;

namespace Kooboo.Commerce.Web.Areas.Commerce.Controllers
{
    public class BrandController : AdminControllerBase
    {
        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        public ActionResult Index(string search,int? page,int? pageSize)
        {
            var lst = this._brandService.Search(search, page, pageSize);
            return View(lst);
        }
    }
}
