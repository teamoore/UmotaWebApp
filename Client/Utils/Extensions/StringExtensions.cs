using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public static class StringExtensions
    {
        public static string MinimizeString(this string str, int? length = null)
        {
            var len = 100;

            if (length.HasValue)
                len = length.Value;

            if (str.Length >= len)
                return str.Substring(0, len) + " ...";

            return str;
        }
    }
}
