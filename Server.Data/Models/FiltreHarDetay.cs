using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class FiltreHarDetay
    {
        public int Logref { get; set; }
        public int FiltreHarRef { get; set; }
        public int? Teklifref { get; set; }
        public int? Teklifdetayref { get; set; }
        public int? LstokFiltreId { get; set; }
        public string LstokFiltreKodu { get; set; }
        public string LstokFiltreAdi { get; set; }
        public DateTime? SevkTarihi { get; set; }
        public DateTime? YenilemeTarihi { get; set; }
        public int? Durum { get; set; }
        public string Aciklama { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
