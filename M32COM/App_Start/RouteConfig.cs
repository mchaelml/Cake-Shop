using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace M32COM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapRoute(
//
//                "ReleaseByDate",
//                "movies/released/{year}/{month}",
//                new { controller = "MoviesController" , action = "ByReleaseDate"},
//                new { year = @"/d{4}" , month = @"/d{2}"}
//
//            ); Example of custom route : 1)name 2) url-path 3) controller 

            routes.MapMvcAttributeRoutes(); // map the Route of Controller ActionResult to here, type [Route(" ")] in Controllers
                                            // above the public ActionResult method 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
