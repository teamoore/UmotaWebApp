using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class CariKullandiklariUrunler
    {
        public int Logref { get; set; }
        public int Cariref { get; set; }
        public int? Sirano { get; set; }
        public string Malzemekodu { get; set; }
        public string Malzemeadi { get; set; }
        public string Grubu { get; set; }
        public string Aciklama { get; set; }
        public string Markaadi { get; set; }
        public string Mensei { get; set; }
        public string Sekli { get; set; }
        public double? TuketimMiktari { get; set; }
        public string Birim { get; set; }
        public double? Fiyat { get; set; }
        public string Doviz { get; set; }
        public bool? Sec { get; set; }
        public byte? Active { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
