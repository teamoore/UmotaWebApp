using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class VCariKartsRequestDto
    {
        public short FirmaId { get; set; }
        public int? lgfirmano { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string SearchText { get; set; }
    }
}
