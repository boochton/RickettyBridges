using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Autofac.Helpers
{
    using System.Reflection;

    using Castle.DynamicProxy;

    using RickettyBridges.API.Autofac.Attributes;

    public class ProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            try
            {
                var attributes = methodInfo.GetCustomAttributes(typeof(EnableInterceptor), true);

                if (attributes.Length > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                // Log, swallow and move on
                return false;
            }

            return false;
        }
    }
}