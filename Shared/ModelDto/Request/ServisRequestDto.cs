using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class ServisRequestDto
    {
        public string SearchText { get; set; }
        public short FirmaId { get; set; }
        public ServisDto Servis { get; set; }
        public string kullanicikodu { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public string Cariadi { get; set; }
        public string Bayiadi { get; set; }
        public string Servisadi { get; set; }
        public string Kisiadi { get; set; }
        public string Istipi { get; set; }
        public string Evrakno { get; set; }
        public int TopRowCount { get; set; }
    }
}
