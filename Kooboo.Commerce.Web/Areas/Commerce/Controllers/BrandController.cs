using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kooboo.Web.Mvc;
using Kooboo.Commerce.Models.Catalog;
using Kooboo.Commerce.Services.Catalog;
using Kooboo.CMS.Common;
using Kooboo.Commerce.Web.Areas.Commerce.Models;
using Kooboo.Commerce.Models;

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand,string @return)
        {
            JsonResultData resultEntry = new JsonResultData(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    if (this.Request.Files.Count > 0)
                    {
                        brand.LogoFile = new EntityFile();
                        brand.LogoFile.FileName = this.Request.Files[0].FileName;
                        brand.LogoFile.Data = this.Request.Files[0].InputStream;
                        brand.LogoFile.CommerceName = AppSetting.CurrentCommerce;
                    }
                    brand.UtcCreateDateTime
                        = brand.UtcUpdateDateTime = DateTime.UtcNow;
                    
                    this._brandService.Add(brand);
                    resultEntry.RedirectUrl = @return;
                }
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }
            return Json(resultEntry);
        }

        public ActionResult Edit(int id)
        {
            var brand = this._brandService.ById(id);
            return View(brand);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand,string @return)
        {
            JsonResultData resultEntry = new JsonResultData(ModelState);

            try
            {
                if (ModelState.IsValid)
                {
                    if (this.Request.Files.Count > 0)
                    {
                        brand.LogoFile = new EntityFile();
                        brand.LogoFile.FileName = this.Request.Files[0].FileName;
                        brand.LogoFile.Data = this.Request.Files[0].InputStream;
                        brand.LogoFile.CommerceName = AppSetting.CurrentCommerce;
                    }
                    brand.UtcUpdateDateTime = DateTime.UtcNow;
                    this._brandService.Update(brand);

                    resultEntry.RedirectUrl = @return;
                }
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }
            return Json(resultEntry);
        }

        [HttpPost]
        public ActionResult Delete(DeleteInfo[] model)
        {
            JsonResultData resultEntry = new JsonResultData(ModelState);
            try
            {
                this._brandService.Delete(model.Select(it=>it.Id).ToArray());
                resultEntry.RedirectUrl = Url.Action("Index", ControllerContext.RequestContext.AllRouteValues().Merge("id", null));
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }
            return Json(resultEntry);
        }
    }
}
