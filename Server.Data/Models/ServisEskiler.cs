using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class ServisEskiler
    {
        public int Logref { get; set; }
        public short? Yil { get; set; }
        public string Bolgeadi { get; set; }
        public string Iladi { get; set; }
        public string Tabelaadi { get; set; }
        public string Musteriadi { get; set; }
        public string Servisadi { get; set; }
        public string Istipi { get; set; }
        public DateTime? Islemtarihi { get; set; }
        public DateTime? Montajtarihi { get; set; }
        public string Servisno { get; set; }
        public string Fisno { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Serino { get; set; }
        public string Aciklama { get; set; }
        public double? Km { get; set; }
        public double? Kmtl { get; set; }
        public double? Yolmasrafi { get; set; }
        public double? Ucret { get; set; }
        public double? Ektra { get; set; }
        public double? Toplambedel { get; set; }
        public string Ozelnot { get; set; }
    }
}
