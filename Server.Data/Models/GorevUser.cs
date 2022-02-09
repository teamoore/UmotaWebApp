using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class GorevUser
    {
        public int Logref { get; set; }
        public int Parlogref { get; set; }
        public string KullaniciKodu { get; set; }
        public byte? Durum { get; set; }
        public short? Tamamlama { get; set; }
        public DateTime? TamamlamaTarihi { get; set; }
        public string Yapilanlar { get; set; }
        public bool? Faaliyet { get; set; }
        public bool? Okundu { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
