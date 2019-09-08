using LynksCodePuzzle.DependancyResolver;
using ShapeGeneratorService.Service;
using ShapeGeneratorService.ServiceIntrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace LynksCodePuzzle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Web API configuration and services

            //Enable Cors
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Set the Dependancy Resolver Property
            var container = new UnityContainer();
            container.RegisterType<IServiceGenerator, ServiceGenerator>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);



        }
    
    }
}
