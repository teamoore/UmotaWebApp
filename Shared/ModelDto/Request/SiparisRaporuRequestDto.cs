using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class SiparisRaporuRequestDto
    {
        public int LogoFirmaNo { get; set; }
        public int LogoDonemNo { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string HizmetKodu { get; set; }
        public string HizmetAdi { get; set; }
        public string SipNo { get; set; }
        public int OnayDurumu { get; set; }
        public int SiparisTuru { get; set; }
        public int SadeceBekleyenler { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public DateTime? BaslangicTeslimTarih { get; set; }
        public DateTime? BitisTeslimTarih { get; set; }
    }
}
