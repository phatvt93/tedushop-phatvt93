using System.Web.Mvc;
using System.Web.Routing;

namespace TeduShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Login",
                "dang-nhap.html",
                new {controller = "Account", action = "Login", id = UrlParameter.Optional},
                new[] {"TeduShop.Web.Controllers"}
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
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}