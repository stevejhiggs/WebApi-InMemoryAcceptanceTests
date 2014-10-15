using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.SelfHostWebApiOwin;

[assembly: OwinStartup(typeof(Repository.Web.Startup))]

namespace Repository.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer());

			//config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			app.UseWebApi(config);
		}
	}
}
