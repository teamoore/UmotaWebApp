using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class Gorev
    {
        public int Logref { get; set; }
        public string KullaniciKodu { get; set; }
        public DateTime Tarih { get; set; }
        public string Konu { get; set; }
        public byte? Oncelik { get; set; }
        public string Yapilacaklar { get; set; }
        public string Tablename { get; set; }
        public int? Tablelogref { get; set; }
        public int? Teklifref { get; set; }
        public DateTime? Insdate { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
