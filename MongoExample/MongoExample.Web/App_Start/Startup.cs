using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Web.Http;
using MongoExample.Web.Storage;

[assembly: OwinStartup(typeof(MongoExample.Web.App_Start.Startup))]

namespace MongoExample.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

            app.UseWebApi(config);

			
			if (ConfigurationManager.AppSettings["Environment"] == "TEST")
			{
				ConfigForTest();
			}
			else
			{
				ConfigForLive();
			}
        }

        public static void ConfigForLive()
        {
            MongoConnection.Configure("mongodb://localhost", "owinMongo");
        }

		public static void ConfigForTest()
		{
			MongoConnection.Configure("mongodb://localhost", "owinMongoTest");
		}
    }
}
