using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Extensions
{
    public static class StringExtensions
    {
        public static string ToValueString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "-";

            return str;
        }
    }
}
