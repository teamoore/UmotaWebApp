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
        public const string MalzemeFiyatGetir = "/api/malzemekart/fiyatgetir";
        public const string TeklifDetayGetir = "/api/teklifdetay/get";
        public const string CariKartAra = "/api/carikart/search";
        public const string CariKartGetir = "/api/carikart/getByKod";
        public const string CariKartListesi = "/api/carikart/list";
        public const string CariKartKaydet = "/api/carikart/save";
        public const string CariKartGuncelle = "/api/carikart/update";
        public const string RefNoAl = "/api/helper/RefNoAl";
        public const string DovizListesi = "/api/doviz/GetDovizList";
        public const string DovizKuruGetir = "/api/doviz/GetDovizKur";
    }
}
