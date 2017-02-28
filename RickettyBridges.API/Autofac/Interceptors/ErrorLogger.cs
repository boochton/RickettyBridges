using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Autofac.Interceptors
{
    using Castle.DynamicProxy;

    using log4net;

    using RickettyBridges.API.Autofac.Attributes;
    using RickettyBridges.API.Autofac.Helpers;

    public class ErrorLogger : IInterceptor
    {
        private const string ErrorCollectingParameterMessage = "There was a problem logging method parameters with the exception";

        public ILog Logger { get; set; }

        public List<string> MethodParametersToLog { get; set; }

        public ErrorLogger(ILog logger)
        {
            Logger = logger;
            MethodParametersToLog = new List<string>();
        }

        public ErrorLogger()
        {
            MethodParametersToLog = new List<string>();
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                try
                {
                    List<string> paramsToInclude;

                    if (MethodParametersToLog == null || !MethodParametersToLog.Any())
                    {
                        paramsToInclude = new List<string>();
                    }
                    else
                    {
                        paramsToInclude = MethodParametersToLog.ToList();
                    }

                    try
                    {
                        var attributes = invocation.Method.GetCustomAttributes(
                            typeof(ParametersToIncludeInException),
                            true);

                        if (attributes.Length > 0)
                        {
                            var attribute = (ParametersToIncludeInException)attributes[0];
                            paramsToInclude.AddRange(attribute.ParameterNames);
                        }
                    }
                    catch (Exception innerEx)
                    {
                        Logger.Error(ErrorCollectingParameterMessage, innerEx);
                    }

                    if (paramsToInclude.Any())
                    {
                        var methodParams = invocation.Method.GetParameters();
                        for (var i = 0; i < methodParams.Length; i++)
                        {
                            var methodArg = invocation.Arguments[i];
                            foreach (var paramToInclude in paramsToInclude)
                            {
                                try
                                {
                                    var paramNameParts = paramToInclude.Split('.');
                                    if (paramNameParts[0].Equals(
                                        methodParams[i].Name,
                                        StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        var propValue = paramNameParts.Count() == 1
                                            ? methodArg
                                            : methodArg.GetPropValue(
                                                paramToInclude.Substring(paramToInclude.IndexOf('.') + 1));
                                        ex.Data[paramToInclude] = propValue ?? "[NULL]";
                                    }
                                }
                                catch (Exception innerEx)
                                {
                                    Logger.Error(ErrorCollectingParameterMessage, innerEx);
                                }
                            }
                        }
                    }
                
                }
                catch (Exception innerEx)
                {
                    Logger.Error(ErrorCollectingParameterMessage, innerEx);
                }

                Logger.Error(string.Format("An error occurred calling {0}", invocation.Method.Name), ex);
            }
        }
    }
}