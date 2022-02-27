using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class UrlHelper
    {
        public const string Login = "api/kullanici/login";
        public const string TeklifListesi = "/api/teklif/list";
        public const string TeklifKaydet = "/api/teklif/save";
        public const string TeklifGuncelle = "/api/teklif/update";
        public const string TeklifAra = "/api/teklif/search";
        public const string TeklifGetir = "/api/teklif/get";
        public const string MalzemeKartAra = "/api/malzemekart/search";
        public const string MalzemeKartGetir = "/api/malzemekart/get";
        public const string TeklifDetayGetir = "/api/teklifdetay/get";
    }
}
