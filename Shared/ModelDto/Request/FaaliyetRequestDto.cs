using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class FaaliyetRequestDto
    {
        public string SearchText { get; set; }
        public short FirmaId { get; set; }
        public FaaliyetDto Faaliyet { get; set; }
        public string kullanicikodu { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public string Cariadi { get; set; }
        public string Kisiadi { get; set; }
        public string Konu { get; set; }
        public string UrunGrubu { get; set; }
        public string Giren { get; set; }
    }
}
