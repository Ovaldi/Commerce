using Kooboo.CMS.Common;
using Kooboo.Commerce.Models;
using Kooboo.Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kooboo.Commerce.Web.Areas.Commerce.Controllers
{
    public class HomeController : AdminControllerBase
    {
        private ICommerceService _commerceService;
        public HomeController(ICommerceService commerceService)
        {
            this._commerceService = commerceService;
        }

        public ActionResult Index()
        {
            return View();
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
                    //TODO:以后需修改为重定向到创建成功站点的首页
                    resultEntry.RedirectUrl = @return;
                }
            }
            catch (Exception ex)
            {
                resultEntry.AddException(ex);
            }
            return Json(resultEntry);
        }
    }
}
