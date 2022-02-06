using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisIsyeri
    {
        public int Logref { get; set; }
        public string FirmaNo { get; set; }
        public short Kodu { get; set; }
        public string Adi { get; set; }
    }
}
