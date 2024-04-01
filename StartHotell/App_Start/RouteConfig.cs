using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StartHotell
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Paymen",
               url: "thanh-toan",
               defaults: new { controller = "Booking", action = "Paymen", id = UrlParameter.Optional },
               namespaces: new[] { "StartHotell.Controllers" }

            );

            routes.MapRoute(
                name: "Success",
                url: "hoan-thanh",
                defaults: new { controller = "Booking", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "StartHotell.Controllers" }

             );

            routes.MapRoute(
               name: "Add Liss",
               url: "them-danh-sach",
               defaults: new { controller = "Booking", action = "AddItemt", id = UrlParameter.Optional },
               namespaces: new[] { "StartHotell.Controllers" }

            );
            routes.MapRoute(
               name: "Liss",
               url: "danh-sach",
               defaults: new { controller = "Booking", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "StartHotell.Controllers" }

            );
            routes.MapRoute(
               name: "Phong",
               url: "phong",
               defaults: new { controller = "Home", action = "Phong" },
               namespaces: new[] { "StartHotell.Controllers" }

              );

            routes.MapRoute(
                 name: "ProductDetail",
                 url: "chi-tiet/{id}",
                 defaults: new { controller = "Home", action = "ProductDetail", id = UrlParameter.Optional },
                 namespaces: new[] { "StartHotell.Controllers" }

              );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "StartHotell.Controllers" }

             );
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "StartHotell.Controllers" }

             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "StartHotell.Controllers" }
            );
        }
    }
}
