using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class UmtMuhasebeTabloDetay
    {
        public int Logref { get; set; }
        public int? Parlogref { get; set; }
        public string Hesno { get; set; }
        public string Hesadi { get; set; }
        public string Ozelkod2 { get; set; }
    }
}
