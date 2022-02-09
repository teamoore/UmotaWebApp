using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class KullaniciTanimlari
    {
        public int Logref { get; set; }
        public string KullaniciKodu { get; set; }
        public int? Plasiyerref { get; set; }
        public string Plasiyerkodu { get; set; }
        public string Teklifinsuserkodu { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public byte? Modul { get; set; }
    }
}
