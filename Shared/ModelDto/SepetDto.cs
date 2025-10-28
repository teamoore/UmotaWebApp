using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SepetDto
    {
        public int ID { get; set; }
        public string SepetAdi { get; set; }
        public int UrunSayisi { get; set; }
        public double ToplamTutar { get; set; }
        public double ToplamTutarTL { get; set; }
        public List<SepetUrunDto> Urunler { get; set; } = new();
        public SepetDto() { }
    }
}
