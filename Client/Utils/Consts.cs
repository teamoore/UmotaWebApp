﻿using System;
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
        public const string CompanyLogo = "companyLogo";
    }

    public class Mesajlar
    {
        public const string MetinGir = "Aranacak metni giriniz.";
        public const string Seciniz = "Seçiniz...";
    }

    public class SabitTip
    {
        public const int DovizKodlari = 1;
        public const int TeklifDurumu = 10;
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

    public class TeklifDurum
    {
        public const string TeklifHazirlaniyor = "Teklif Hazırlanıyor";
        public const string TeklifMusteriyeGonderildi = "Teklif Müşteriye Gönderildi";
        public const string MusteriOnayiBekliyor = "Müşteri Onayı Bekliyor";
        public const string MusteriTeklifiOnayladi = "Müşteri Teklifi Onayladı";
        public const string MusteriTeklifteRevizeIstedi = "Müşteri Teklifte Revize İstedi";
        public const string MusteriTeklifiIptalEtti = "Müşteri Teklifi İptal Etti";
        public const string UnoTeklifiIptalEtti = "Uno Teklifi İptal Etti";
        public const string FinansalUygunlukBekleniyor = "Finansal Uygunluk Bekliyor";
        public const string FinansalUygunlukVer = "Finansal Uygunluk Ver";
        public const string KesinSiparis = "Kesin Sipariş";
        public const string KesinSipLogoyaAktarildi = "Kesin Sipariş Logoya Aktarıldı";
    }

}
