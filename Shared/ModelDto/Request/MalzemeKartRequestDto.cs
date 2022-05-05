using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeKartRequestDto
    {
        public MalzemeKartDto MalzemeKart { get; set; }
        public short FirmaId { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string Marka { get; set; }
        public string SearchText { get; set; }
    }
}
