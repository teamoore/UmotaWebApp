using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V041FiltreMontaj
    {
        public int Logref { get; set; }
        public int? Teklifref { get; set; }
        public int? Teklifdetayref { get; set; }
        public int? LstokMainId { get; set; }
        public string LstokMainKodu { get; set; }
        public string LstokMainAdi { get; set; }
        public int? LstokFiltreId { get; set; }
        public string LstokFiltreKodu { get; set; }
        public string LstokFiltreAdi { get; set; }
        public DateTime? MontajTarihi { get; set; }
        public string MontajYeri { get; set; }
        public string Aciklama { get; set; }
        public string TekrarlamaSekli { get; set; }
        public int? TekrarlamaSuresi { get; set; }
        public int? Durum { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public string Neden { get; set; }
        public string Teklifno { get; set; }
        public DateTime? Tarih { get; set; }
        public string Carikodu { get; set; }
        public string Cariadi { get; set; }
        public string Proje { get; set; }
        public string Malzkodu { get; set; }
        public string Malzadi { get; set; }
        public string SetMalzkodu { get; set; }
        public string SetMalzadi { get; set; }
    }
}
