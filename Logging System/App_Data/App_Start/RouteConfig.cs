using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Logging_System
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


           

            routes.MapRoute(
                  name: "Weekly",
                  url: "Weekly/{*path}",
                  defaults: new
                  {
                      controller = "Weekly",
                      action = "WeeklyDownloads",
                      path = UrlParameter.Optional
                  }
                                  );

            routes.MapRoute(
                  name: "Monthly",
                  url: "Monthly/{*path}",
                  defaults: new
                  {
                      controller = "Monthly",
                      action = "MonthlyDownloads",
                      path = UrlParameter.Optional
                  }
                                  );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    //For safety reasons

    //public class RouteConfig
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        routes.MapRoute(
    //            name: "Default",
    //            url: "{controller}/{action}/{id}",
    //            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    //        );
    //    }
    //}
}
