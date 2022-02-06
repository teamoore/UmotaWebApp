using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisFirmaDonem
    {
        public int Logref { get; set; }
        public short? FirmaNo { get; set; }
        public short? Yil { get; set; }
        public short? LogoFirma { get; set; }
        public short? LogoDonem { get; set; }
        public byte? Ondeger { get; set; }
        public string Aciklama { get; set; }
    }
}
