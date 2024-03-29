﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sushi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Create",
                url: "Products/Create",
                defaults: new { controller = "Products", action = "Create" }
            );
            routes.MapRoute(
                name: "AddToCart",
                url: "Them-gio-hang/{idaddcart}",
                defaults: new { controller = "GioHang", action = "themGioHang", idaddcart = UrlParameter.Optional }
);
        }
    }
}
