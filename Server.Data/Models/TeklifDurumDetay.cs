using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifDurumDetay
    {
        public int Refid { get; set; }
        public int? Teklifref { get; set; }
        public DateTime? Tarih { get; set; }
        public string Duruminfo { get; set; }
        public string Aciklama { get; set; }
        public string KullaniciKodu { get; set; }
    }
}
