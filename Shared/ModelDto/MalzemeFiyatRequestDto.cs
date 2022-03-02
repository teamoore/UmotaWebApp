using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeFiyatRequestDto
    {
        public int LogoFirmaNo { get; set; }
        public int UmotaFirmaNo { get; set; }
        public int MalzemeRef { get; set; }
        public int DovizRef { get; set; }
        public string BirimKodu { get; set; }
        public string CariKodu { get; set; }
        public DateTime Tarih { get; set; }
    }
}
