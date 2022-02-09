using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class ServisMalzemeler
    {
        public int Logref { get; set; }
        public int Servisref { get; set; }
        public string Tur { get; set; }
        public int Stokref { get; set; }
        public string LstokKodu { get; set; }
        public string LstokAdi { get; set; }
        public string Serino { get; set; }
        public bool? Garanti { get; set; }
        public string Birim { get; set; }
        public double? Miktar { get; set; }
        public double? Fiyat { get; set; }
        public double? Tutar { get; set; }
        public string Aciklama { get; set; }
        public string Durum { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
