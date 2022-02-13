using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class Consts
    {
        public const string KullaniciKodu = "kullanicikodu";
        public const string FirmaDonem = "firmaNo";
        public const string FirmaDonemYetki = "firmadonemyetki";
        public const string Token = "token";
    }

    public static class ExtensionHelpers
    {
        public static string ClearCharacters(this string str)
        {
            var cleanStr = str.Replace("'", "");
            cleanStr = cleanStr.Replace("\"", "");
            
            return cleanStr;
        }
    }
}
