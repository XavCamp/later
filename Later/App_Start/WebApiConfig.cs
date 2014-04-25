using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace Later
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}"
			);

			config.Routes.MapHttpRoute(
				name: "sendMail",
				routeTemplate: "api/capsules/mail/{id}",
				defaults: new { action = "mail", controller = "capsules" }
			);
		}
	}
}
