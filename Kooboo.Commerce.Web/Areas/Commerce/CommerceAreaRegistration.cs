using Kooboo.Web.Mvc;
using System.IO;
using System.Web.Mvc;

namespace Kooboo.Commerce.Web.Areas.Commerce
{
    public class CommerceAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Commerce";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            /*
            context.MapRoute(
                "Commerce_default",
                "Commerce/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );*/
            context.MapRoute(
               AreaName + "_default",
                AreaName + "/{controller}/{action}",
                new { controller = "Home", action = "Index" }
                , null
                , new[] { "Kooboo.Commerce.Web.Controllers", "Kooboo.Commerce.Web.Areas.Commerce.Controllers", "Kooboo.Web.Mvc", "Kooboo.Web.Mvc.WebResourceLoader" }
            );

            var menuFile = AreaHelpers.CombineAreaFilePhysicalPath(AreaName, "Menu.config");
            if (File.Exists(menuFile))
            {
                Kooboo.Web.Mvc.Menu.MenuFactory.RegisterAreaMenu(AreaName, menuFile);
            }
            var resourceFile = Path.Combine(Settings.BaseDirectory, "Areas", AreaName, "WebResources.config");
            if (File.Exists(resourceFile))
            {
                Kooboo.Web.Mvc.WebResourceLoader.ConfigurationManager.RegisterSection(AreaName, resourceFile);
            }
        }
    }
}
