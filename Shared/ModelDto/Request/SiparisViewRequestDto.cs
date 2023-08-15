using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SiparisViewRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public int TopRowCount { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public int? ProjeRef { get; set; }
        public int? SiparisDurumu { get; set; }
        public int? OnayDurumu { get; set; }
        public SiparisDto Siparis { get; set; }
    }
}
