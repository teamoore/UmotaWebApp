using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SepetUrunDto
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string UrunBaslik { get; set; }
        public string Foto { get; set; }
        public double Fiyat { get; set; }
        public double FiyatTL { get; set; }
        public double Miktar { get; set; }
        public int HesaplananAdet { get; set; }
        public SepetUrunDto()
        {
        }
    }
}
