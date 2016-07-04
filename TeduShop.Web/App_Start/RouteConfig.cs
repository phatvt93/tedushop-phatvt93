using System.Web.Mvc;
using System.Web.Routing;

namespace TeduShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                "Search",
                "tim-kiem.html",
                new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                new[] { "TeduShop.Web.Controllers" }
                );

            routes.MapRoute(
                "Tag List",
                "tag/{tagId}.html",
                new { controller = "Product", action = "ListByTag", tagId = UrlParameter.Optional },
                new[] { "TeduShop.Web.Controllers" }
                );

            routes.MapRoute(
                "Login",
                "dang-nhap.html",
                new {controller = "Account", action = "Login", id = UrlParameter.Optional},
                new[] {"TeduShop.Web.Controllers"}
                );

            routes.MapRoute(
                "Register",
                "dang-ky.html",
                new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                new[] { "TeduShop.Web.Controllers" }
                );

            routes.MapRoute(
                "About",
                "gioi-thieu.html",
                new {controller = "About", action = "Index", id = UrlParameter.Optional},
                new[] {"TeduShop.Web.Controllers"}
                );

            routes.MapRoute(
                "Product Category",
                "{alias}.pc-{id}.html",
                new {controller = "Product", action = "Category", id = UrlParameter.Optional},
                new[] {"TeduShop.Web.Controllers"}
                );

            routes.MapRoute(
                "Product",
                "{alias}.p-{productId}.html",
                new {controller = "Product", action = "Detail", productId = UrlParameter.Optional},
                new[] {"TeduShop.Web.Controllers"}
                );

            routes.MapRoute(
                "Contact",
                "lien-he.html",
                new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                new[] { "TeduShop.Web.Controllers" }
                );

            routes.MapRoute(
               "Page",
               "trang/{alias}.html",
               new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
               new[] { "TeduShop.Web.Controllers" }
               );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}