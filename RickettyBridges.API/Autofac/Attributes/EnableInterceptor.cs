using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Autofac.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class EnableInterceptor : Attribute
    {
        public EnableInterceptor(params string[] interceptorNames)
        {
            InterceptorNames = interceptorNames.ToList();
        }

        public List<string> InterceptorNames { get; set; } 
    }
}