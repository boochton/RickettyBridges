using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Util
{
    using System.Diagnostics;
    using System.IO;

    using Microsoft.Ajax.Utilities;

    public static class Assert
    {
        [DebuggerHidden]
        public static void IsNotNull(object itemToTest, string name)
        {
            if (itemToTest == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        [DebuggerHidden]
        public static void IsDate(object itemToTest, string name, out DateTime date)
        {
            IsNotNull(itemToTest, name);

            if (!DateTime.TryParse(itemToTest.ToString(), out date))
            {
                throw new InvalidDataException(name);
            }
        }   
    }
}