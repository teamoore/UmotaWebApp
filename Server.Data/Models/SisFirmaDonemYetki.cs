using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisFirmaDonemYetki
    {
        public int Logref { get; set; }
        public int? Donemref { get; set; }
        public byte? Tur { get; set; }
        public string Kodu { get; set; }
    }
}
