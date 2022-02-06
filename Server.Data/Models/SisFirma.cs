using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisFirma
    {
        public string FirmaNo { get; set; }
        public string FirmaAdi { get; set; }
        public bool? LogoStokKart { get; set; }
        public bool? LogoCariKart { get; set; }
        public bool? LogoHizmetKart { get; set; }
        public string LogoFirmaNo { get; set; }


    }
}
