using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class SepetPostDto
    {
        public string KullaniciKodu { get; set; }
        public string SepetAdi { get; set; }
        public int UrunID { get; set; }
        public double Miktar { get; set; }
        public double Fiyat { get; set; }

    }
}
