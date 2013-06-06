using Kooboo.CMS.Common;
using Kooboo.Commerce.Models;
using Kooboo.Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kooboo.Web.Mvc;
using Kooboo.Web.Mvc.Paging;

namespace Kooboo.Commerce.Web.Areas.Commerce.Controllers
{
    public class HomeController : AdminControllerBase
    {
        private ICommerceService _commerceService;
        public HomeController(ICommerceService commerceService)
        {
            this._commerceService = commerceService;
        }

        public ActionResult Index(string search,int? page,int? pageSize)
        {
            var query = this._commerceService.Search(search);
            var model = query.ToPagedList(page ?? 1, pageSize ?? 50);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommerceSetting setting,string @return)
        {
            JsonResultData resultEntry = new JsonResultData(ModelState);
            try
            {
                if (ModelState.IsValid)
                {
                    this._commerceService.Add(setting);
                    resultEntry.RedirectUrl = Url.Action("Index", "Brand", new { CommerceName = setting.Name });
                }
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }
            return Json(resultEntry);
        }

        public ActionResult Delete(string commerceName)
        {
            var model = this._commerceService.GetByName(commerceName);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string commerceName,string @return)
        {
            JsonResultData resultEntry = new JsonResultData(ModelState);

            try
            {
                this._commerceService.Delete(commerceName);
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }

            return Json(resultEntry);
        }
    }
}
