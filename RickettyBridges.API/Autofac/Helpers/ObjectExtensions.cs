using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Autofac.Helpers
{
    using System.Globalization;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static object GetPropValue(this object obj, string name)
        {
            string str = name;
            char[] chArray = new char[1] { '.' };

            foreach (string name1 in str.Split(chArray))
            {
                if (obj == null) return (object)null;
                var property = obj.GetType().GetProperty(name1);
                if (property == (PropertyInfo) null) return (object)null;
                obj = property.GetValue(obj, (object[])null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this object obj, string name)
        {
            object propValue = ObjectExtensions.GetPropValue(obj, name);
            if (propValue == null) return default (T);
            return (T)propValue;
        }

        public static void SetPropValue(this object obj, string propName, object value)
        {
            PropertyInfo property = obj.GetType().GetProperty(propName);
            Type propertyType = property.PropertyType;
            object obj1 = Convert.ChangeType(value, propertyType);
            property.SetValue(obj, obj1, BindingFlags.SetProperty, (Binder) null, (object[]) null, (CultureInfo) null);
        }
    }
}