using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace CentralLog.Web
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );

      var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}