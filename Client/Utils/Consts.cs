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
        public const string CompanyLogo = "companyLogo";
        public const string DonemFirmalar = "donemFirmalar";

        public const string TeklifSozlesmesi = @"1.Fiyatlarımıza KDV dahil değildir. Teklifteki fiyatlarımız iskonto yapılmış net fiyatlardır. 
2.Döviz kuru ödemenin gerçekleştiği veya faturanın kesildiği günden hesaplanacaktır.   
3.Her türlü tesisat işleri (Elektrik, Sıcak-Soğuk Su, Sifon ve Sübab, LG,NG veya Havagazı ,Havalandırma vs….)teklif dışıdır. 
4.Teslim Süresi: Sipariş onayı ile stokta olan ürünler hemen, olmayanlar 4-6 haftadır. 
5.Ödeme Şekli: Sipariş onayı ile %50 peşin kalanı mal tesliminden önce. 
6.Nakliye: Nakliye dahil değildir. Ürünlerin mahallere taşınması alıcıya aittir. 
Ürünlerin mahaller taşınması için gerekli her türlü vinç, forklift vb. taşıma aletlerinin temini alıcıya aittir. 
7.Montaj: Türkiye içi montaj hizmeti verilebilir. Ücreti anlaşmaya bağlıdır. 
8.Proje kapsamında yapılan özel imalat ürünler kesinlikle iade alınmaz. 
9.Montaj: Proje montajı esnasında ALICI imza yetkilisinin şantiyede bulunması ve 'Proje Montaj Tutanağı' nı kaşeli olarak imzalaması zorunludur. 
10.Remote soğutmalı bütün üniteler için, ( soğuk oda, derin dondurucu, buzdolabı vb.) 10 mt ye kadar borulama fiyat teklife dahildir. 
Bu mesafe üzeri ayrıca fiyatlandırılacaktır.
11.Soğuk oda- derin dondurucu  ünitelerin zemin ile ilgili yapılacak her türlü inşai işler (zemin fayans, izolasyon vs.) 
ve dış ünitelerin koyulacağı yerdeki demir taşıyıcı karkaslar alıcı teminidir.";
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
}
