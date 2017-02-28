using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.App_Start
{
    using System.Web.Http;

    using Autofac;

    using Castle.DynamicProxy;
    using Castle.DynamicProxy.Generators;

    using global::Autofac;
    using global::Autofac.Extras.DynamicProxy;
    using global::Autofac.Integration.WebApi;

    using log4net;

    using Microsoft.Ajax.Utilities;

    using RickettyBridges.API.Autofac.Helpers;
    using RickettyBridges.API.Autofac.Interceptors;
    using RickettyBridges.API.Controllers;
    using RickettyBridges.DAL;
    using RickettyBridges.DAL.Interfaces;

    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<RickettyBridgesContext>();    
            builder.RegisterType<RickettyBridgesService>().As<IRickettyBridgeService>();

            builder.RegisterInstance(LogManager.GetLogger("Logger")).As<ILog>().SingleInstance();

            builder.RegisterType<ErrorLogger>();         

            var proxyGenerationOptions = new ProxyGenerationOptions(new ProxyGenerationHook());

            builder.RegisterType<VersionController>()
                .InstancePerRequest()
                .InterceptedBy(typeof(ErrorLogger))
                .EnableClassInterceptors(proxyGenerationOptions);

            builder.RegisterType<AssetController>()
                .InstancePerRequest()
                .InterceptedBy(typeof(ErrorLogger))
                .EnableClassInterceptors(proxyGenerationOptions);

            builder.RegisterType<ReferenceDataController>()
                .InstancePerRequest()
                .InterceptedBy(typeof(ErrorLogger))
                .EnableClassInterceptors(proxyGenerationOptions);

            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }        
    }
}