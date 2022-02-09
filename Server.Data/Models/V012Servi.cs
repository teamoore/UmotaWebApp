using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V012Servi
    {
        public int Logref { get; set; }
        public string Istipi { get; set; }
        public DateTime Tarih { get; set; }
        public short Yil { get; set; }
        public DateTime? BildirimTarihi { get; set; }
        public string Fisno { get; set; }
        public string Evrakno { get; set; }
        public int? Cariref { get; set; }
        public string LcariKodu { get; set; }
        public string LcariAdi { get; set; }
        public int? Bayiref { get; set; }
        public string LbayiKodu { get; set; }
        public string LbayiAdi { get; set; }
        public int? Tservisref { get; set; }
        public string LtservisKodu { get; set; }
        public string LtservisAdi { get; set; }
        public string IslemAdresi { get; set; }
        public int? IslemSehirRef { get; set; }
        public string IslemSehir { get; set; }
        public string IslemIlce { get; set; }
        public string IslemBolge { get; set; }
        public string KimYonlendirdi { get; set; }
        public DateTime? Bastarih { get; set; }
        public DateTime? Bittarih { get; set; }
        public string IsTanimi { get; set; }
        public string Yapilanlar { get; set; }
        public string IlgiliKisi { get; set; }
        public string IlgiliTel { get; set; }
        public bool? Garanti { get; set; }
        public string Yonlendirenkisi { get; set; }
        public string Durum { get; set; }
        public string Orderref { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public string BayiIlgiliKisi { get; set; }
        public string BayiIlgiliTel { get; set; }
        public string ServisIlgiliKisi { get; set; }
        public string ServisIlgiliTel { get; set; }
        public double? Toptutar { get; set; }
        public bool? Mailmusteri { get; set; }
        public bool? Mailservis { get; set; }
        public DateTime? Mailmusteritar { get; set; }
        public DateTime? Mailservistar { get; set; }
        public byte? Serinovar { get; set; }
        public bool? Karaliste { get; set; }
        public string Not1 { get; set; }
        public bool? Mailbayi { get; set; }
        public bool? Mailbayitar { get; set; }
        public string Bayikodu { get; set; }
        public string Bayiadi { get; set; }
        public string Carikodu { get; set; }
        public string Cariadi { get; set; }
        public string Serviskodu { get; set; }
        public string Servisadi { get; set; }
        public string Il { get; set; }
    }
}
