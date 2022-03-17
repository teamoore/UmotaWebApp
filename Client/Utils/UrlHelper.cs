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
        public const string TeklifDurumGuncelle = "/api/teklif/updatedurum";
        public const string TeklifAra = "/api/teklif/search";
        public const string TeklifGetir = "/api/teklif/get";
        public const string MalzemeKartAra = "/api/malzemekart/search";
        public const string MalzemeKartGetir = "/api/malzemekart/get";
        public const string MalzemeFiyatGetir = "/api/malzemekart/fiyatgetir";
        public const string MalzemeMaliyetGetir = "/api/malzemekart/maliyetgetir";
        public const string TeklifDetayGetir = "/api/teklifdetay/get";
        public const string CariKartAra = "/api/carikart/search";
        public const string CariKartGetir = "/api/carikart/getByKod";
        public const string CariKartGetirLogRef = "/api/carikart/get";
        public const string CariKartListesi = "/api/carikart/list";
        public const string CariKartKaydet = "/api/carikart/save";
        public const string CariKartGuncelle = "/api/carikart/update";
        public const string RefNoAl = "/api/helper/RefNoAl";
        public const string DovizListesi = "/api/doviz/GetDovizList";
        public const string DovizKuruGetir = "/api/doviz/GetDovizKur";
        public const string TeklifDetaySiraNo = "/api/teklifdetay/getsirano";
        public const string KullaniciGetByKod = "/api/kullanici/GetByKod";
        public const string FaaliyetListesi = "/api/faaliyet/list";
        public const string FaaliyetAra = "/api/faaliyet/search";
        public const string FaaliyetGetir = "/api/faaliyet/get";
        public const string FaaliyetKaydet = "/api/faaliyet/save";
        public const string FaaliyetGuncelle = "/api/faaliyet/update";
    }
}
