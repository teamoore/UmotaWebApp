using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class TahsilatRaporuRequestDto
    {
        public int LogoFirmaNo { get; set; }
        public int LogoDonemNo { get; set; }
        public string CariKodu { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
    }
}
