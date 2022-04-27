using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class CariDurumRaporuRequestDto
    {
        public int LogoFirmaNo { get; set; }
        public int LogoDonemNo { get; set; }
        public string BaslangicCariKodu { get; set; }
        public string BitisCariKodu { get; set; }
        public int BakiyeSecimi { get; set; }
        public DateTime? RaporTarihi { get; set; }
        public string SearchText { get; set; }
    }
}
