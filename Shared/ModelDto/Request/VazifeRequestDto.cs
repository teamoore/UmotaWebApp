using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class VazifeRequestDto : BaseRequestDto
    {
        public bool AdminView { get; set; }
        public VazifeDto Vazife { get; set; }
        public string InsUser { get; set; }
        public string AtananUser { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public string Cariadi { get; set; }
        public string Kisiadi { get; set; }
        public byte? Oncelik { get; set; }
        public byte? Yapildi { get; set; }

        public byte? Arsiv { get; set; }
        public string LoginOlanKullanici { get; set; }
    }
}
