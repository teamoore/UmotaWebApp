using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V004Sevkadre
    {
        public int Logref { get; set; }
        public string Sevkkodu { get; set; }
        public string SevkEdilecekBayiAdi { get; set; }
        public string Sevkadres1 { get; set; }
        public string Sevkadres2 { get; set; }
        public string Semt { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        public string Ulke { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Faks { get; set; }
        public string Mail { get; set; }
        public string Postakodu { get; set; }
        public string Vdno { get; set; }
        public string Vdadi { get; set; }
        public short? Durumu { get; set; }
        public int? Clientref { get; set; }
        public string SevkIlgilisi { get; set; }
    }
}
