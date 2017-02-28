using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Autofac.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ParametersToIncludeInException : Attribute
    {
        public ParametersToIncludeInException(params string[] parameterNames)
        {
            ParameterNames = parameterNames.ToList();
        }

        public List<string> ParameterNames { get; set; }
    }
}