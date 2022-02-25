using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SisFirmaDonemDto
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
