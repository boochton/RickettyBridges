using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RickettyBridges.API.Controllers
{
    using System.Diagnostics;

    using log4net;
    using log4net.Core;

    using RickettyBridges.API.Autofac.Attributes;

    public class VersionController : ApiControllerBase
    {
        public VersionController(ILog logger)
            : base(logger)
        {            
        }

        [HttpGet]
        [Route("api/version")]
        [EnableInterceptor]
        public virtual string Version()
        {
            Logger.Info("Retreiving version number");
            var type = this.GetType();
            if (type.Assembly.GetName().Name == "DynamicProxyGenAssembly2")
            {
                type = type.BaseType;
            }
            return FileVersionInfo.GetVersionInfo(type.Assembly.Location).FileVersion;
        }
    }
}
