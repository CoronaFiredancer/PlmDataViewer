using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PlmConnector.Connectors;
using PlmConnector.Services;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			//Autofac configuration
			var builder = new ContainerBuilder();
	        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

	        builder.RegisterType<ArasConnector>().As<IConnector>().SingleInstance();
			builder.RegisterType<PartsService>().As<IPartsService>().InstancePerLifetimeScope();

	        var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
