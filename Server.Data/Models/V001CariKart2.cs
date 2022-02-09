using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V001CariKart2
    {
        public int Logref { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Adi2 { get; set; }
        public string Adres1 { get; set; }
        public string Vdno { get; set; }
        public short? Active { get; set; }
        public short? Status { get; set; }
    }
}
