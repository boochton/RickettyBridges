using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RickettyBridges.API.Controllers
{
    using System.Runtime.Remoting.Messaging;

    using global::Autofac.Integration.WebApi;

    using log4net;

    using RickettyBridges.API.Util;

    [AutofacControllerConfiguration]
    public class ApiControllerBase : ApiController
    {
        public ILog Logger { get; set; }

        public ApiControllerBase(ILog logger)
        {
            Assert.IsNotNull(logger, "logger");            
            Logger = logger;
        }
    }
}
