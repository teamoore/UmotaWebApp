using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V029Teklif
    {
        public int Logref { get; set; }
        public string Teklifno { get; set; }
        public string Revzno { get; set; }
        public int? Revizyon { get; set; }
        public string Tbelgeno { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? Saat { get; set; }
        public short? Caritip { get; set; }
        public int? Cariref { get; set; }
        public string LcariKodu { get; set; }
        public string LcariAdi { get; set; }
        public int? Carisevkadrref { get; set; }
        public string LcariSevkadrKodu { get; set; }
        public int? LodemePlani { get; set; }
        public string LodemePlaniKodu { get; set; }
        public int? Lpersonelref { get; set; }
        public string Lpersoneladi { get; set; }
        public string Proje { get; set; }
        public string IlgiliAdi { get; set; }
        public string TeslimSekli { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string Aciklama4 { get; set; }
        public int? Dovizref { get; set; }
        public double? Dovizkuru { get; set; }
        public double? Tutar { get; set; }
        public double? Tutartl { get; set; }
        public double? Tutarrd { get; set; }
        public double? Tutarmatrah { get; set; }
        public double? Tutarmatrahtl { get; set; }
        public double? Tutarmatrahrd { get; set; }
        public string Lfirma { get; set; }
        public string Ldonem { get; set; }
        public string Duruminfo { get; set; }
        public string Notlar { get; set; }
        public string Logoentegre { get; set; }
        public DateTime? Logotar { get; set; }
        public int? Logosipref { get; set; }
        public int? Dovizrefid { get; set; }
        public double? Dovizkuruid { get; set; }
        public double? Gniskoran { get; set; }
        public double? Gnisktutar { get; set; }
        public bool? Gnistip { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public byte? Trcode { get; set; }
        public string Carikodu { get; set; }
        public string Cariadi { get; set; }
        public string Odemeplanikodu { get; set; }
        public string Odemeplaniadi { get; set; }
        public string Temsilcikodu { get; set; }
        public string Temsilciadi { get; set; }
        public string Dovizdoku { get; set; }
        public string Dovizdokuid { get; set; }
        public string Sevkkodu { get; set; }
        public string SevkEdilecekBayiAdi { get; set; }
        public string Sevkadres1 { get; set; }
        public string Sevkadres2 { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string SevkIlgilisi { get; set; }
        public string Faks { get; set; }
        public string Mail { get; set; }
    }
}
