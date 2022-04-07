using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class Takvim
    {
        public int Logref { get; set; }

        public DateTime? Tarih { get; set; }

        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public int? CariRef { get; set; }
        public string Cari_Kodu { get; set; }
        public string Cari_Adi { get; set; }
        public byte? Yapildi { get; set; }

        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}