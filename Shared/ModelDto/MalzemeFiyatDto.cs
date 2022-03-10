using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeFiyatDto
    {
        public int MalzemeRef { get; set; }
        public double Fiyat { get; set; }
        public int DovizRef { get; set; }
        public string DovizKodu { get; set; }
        public int FiyatBirimRef { get; set; }
        public string FiyatBirimKodu { get; set; }
        public int FiyatBirimSetiRef { get; set; }
        public byte? KdvDahil { get; set; }
        public double OzelFiyat { get; set; }
    }
}
