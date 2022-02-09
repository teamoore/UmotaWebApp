using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class Faaliyet
    {
        public int Logref { get; set; }
        public string Giren { get; set; }
        public DateTime? Tarih { get; set; }
        public string Konu { get; set; }
        public int? IslemSayisi { get; set; }
        public string Yapilanlar { get; set; }
        public int? Cariref { get; set; }
        public int? Malzemeref { get; set; }
        public int? Kisiref { get; set; }
        public int? Kisiref2 { get; set; }
        public int? Kisiref3 { get; set; }
        public int? Kisiref4 { get; set; }
        public int? Kisiref5 { get; set; }
        public string Grup1 { get; set; }
        public string Grup2 { get; set; }
        public string Grup3 { get; set; }
        public string Grup4 { get; set; }
        public string Grup5 { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public byte? Islemturu { get; set; }
    }
}
