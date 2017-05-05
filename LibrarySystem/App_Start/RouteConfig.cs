using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibrarySystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Details Book",
                url: "Book/Details/{id}",
                defaults: new { controller = "Book", action = "Details", id = 0 }
            );

            routes.MapRoute(
                name: "Details Authors",
                url: "Author/Details/{id}",
                defaults: new { controller = "Author", action = "Details", id = 0 }
            );

            routes.MapRoute(
                name: "Delete Book",
                url: "Book/Delete/{id}",
                defaults: new { controller = "Book", action = "Delete", id = 0 }
            );

            routes.MapRoute(
                name: "Edit Book",
                url: "Book/Edit/{id}",
                defaults: new { controller = "Book", action="Edit", id = 0 }
            );

            routes.MapRoute(
                name: "Edit Author",
                url: "Author/Edit/{id}",
                defaults: new { controller = "Author", action = "Edit", id = 0 }
            );

            

            routes.MapRoute(
                name: "Book",
                url: "Book/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );

            

            routes.MapRoute(
                name: "Author",
                url: "Author/{action}/{id}",
                defaults: new { controller = "Author", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
