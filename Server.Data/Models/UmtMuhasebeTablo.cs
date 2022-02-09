using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class UmtMuhasebeTablo
    {
        public int Logref { get; set; }
        public int? Sirano { get; set; }
        public string Kodu { get; set; }
        public string Aciklama { get; set; }
        public short? Firma { get; set; }
    }
}
