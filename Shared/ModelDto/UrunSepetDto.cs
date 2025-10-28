using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class UrunSepetDto
    {
        public int ID { get; set; }
        public string KullaniciKodu { get; set; }
        public string SepetAdi { get; set; }
        public int UrunID { get; set; }
        public double Miktar { get; set; }
        public double Fiyat { get; set; }
        public double FiyatTL { get; set; }
        public int HesaplananAdet { get; set; }

    }
}
