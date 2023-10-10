using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ApiWithExtension",
                routeTemplate: "api/{controller}.{fileEtension}",
                defaults: new { }
            );

            config.Routes.MapHttpRoute(
                name: "ApiWithExtensionAndID",
                routeTemplate: "api/{controller}.{fileEtension}/{id}",
                defaults: new { id = RouteParameter.Optional, fileExtension = RouteParameter.Optional }
            );

            
        }
    }
}
