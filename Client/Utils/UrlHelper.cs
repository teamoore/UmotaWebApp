using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class UrlHelper
    {
        public const string Login = "api/kullanici/login";
        public const string GetKullaniciYetkisi = "api/kullanici/GetKullaniciYetkisi";
        public const string TeklifListesi = "/api/teklif/list";
        public const string TeklifKaydet = "/api/teklif/save";
        public const string TeklifGuncelle = "/api/teklif/update";
        public const string TeklifDurumGuncelle = "/api/teklif/updatedurum";
        public const string TeklifDurumDetayList = "/api/teklif/teklifdurumlist";
        public const string TeklifAra = "/api/teklif/search";
        public const string TeklifGetir = "/api/teklif/get";
        public const string TeklifSil = "/api/teklif/delete";
        public const string TeklifKaydetRevize = "/api/teklif/saverevize";
        public const string MalzemeKartListesi = "/api/malzemekart/list";
        public const string MalzemeKartAra = "/api/malzemekart/search";
        public const string MalzemeKartGetir = "/api/malzemekart/get";
        public const string VMalzemeKartGetir = "/api/vmalzemekart/get";
        public const string MalzemeFiyatGetir = "/api/malzemekart/fiyatgetir";
        public const string MalzemeMaliyetGetir = "/api/malzemekart/maliyetgetir";
        public const string MalzemeStokGetir = "/api/malzemekart/stokgetir";
        public const string MalzemeKartSave = "/api/malzemekart/save";
        public const string MalzemeKartUpdate = "/api/malzemekart/update";
        public const string TeklifDetayGetir = "/api/teklifdetay/get";
        public const string CariKartAra = "/api/carikart/search";
        public const string CariKartGetir = "/api/carikart/getByKod";
        public const string CariKartGetirLogRef = "/api/carikart/get";
        public const string CariKartListesi = "/api/carikart/list";
        public const string CariKartKaydet = "/api/carikart/save";
        public const string CariKartGuncelle = "/api/carikart/update";
        public const string CariKartKisiGetir = "/api/kisiler/getcarikisiler";
        public const string CariKartKisiKaydet = "/api/kisiler/savekisi";
        public const string CariKartKisiGuncelle = "/api/kisiler/updatekisi";
        public const string RefNoAl = "/api/helper/RefNoAl";
        public const string CariSektorList = "/api/helper/GetCariSektorList";
        public const string DovizListesi = "/api/doviz/GetDovizList";
        public const string DovizKuruGetir = "/api/doviz/GetDovizKur";
        public const string TeklifDetaySiraNo = "/api/teklifdetay/getsirano";
        public const string KullaniciGetByKod = "/api/kullanici/GetByKod";
        public const string KullaniciMenuYetkisi = "/api/kullanici/GetKullaniciMenuYetkisi";
        public const string FaaliyetListesi = "/api/faaliyet/list";
        public const string FaaliyetAra = "/api/faaliyet/search";
        public const string FaaliyetGetir = "/api/faaliyet/get";
        public const string FaaliyetKaydet = "/api/faaliyet/save";
        public const string FaaliyetGuncelle = "/api/faaliyet/update";
        public const string FaaliyetSil = "/api/faaliyet/delete";
        public const string CariFaaliyetSayisi = "/api/faaliyet/getcarifaaliyetsayisi";
        public const string VCariKartListesi = "/api/vcarikart/list";
        public const string VCariKartAra = "/api/vcarikart/search";
        public const string VCariKartGetir = "/api/vcarikart/get";
        public const string VCariKartAdresListesi = "/api/vcarikart/adreslist";
        public const string GetKullaniciListesi = "/api/kullanici/list";
        public const string GetKullaniciGrupListesi = "/api/kullanici/gruplist";
        public const string KullaniciSave = "/api/kullanici/save";
        public const string KullaniciUpdate = "/api/kullanici/update";
        public const string DashboardPersonelTeklifSatis = "/api/Dashboard/personelteklif";
    }
}
