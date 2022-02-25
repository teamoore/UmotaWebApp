using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SisSabitlerDetayDto
    {
        public int SabitDetayId { get; set; }
        public short Tip { get; set; }
        public string Kodu { get; set; }
        public int? Ikodu { get; set; }
        public string Adi { get; set; }
        public string YabanciAdi { get; set; }
        public short Siralama { get; set; }
        public string OzelKod1 { get; set; }
        public string OzelKod2 { get; set; }
        public string OzelKod3 { get; set; }
        public int? OzelKod4 { get; set; }
        public int? OzelKod5 { get; set; }
        public int? OzelKod6 { get; set; }
        public double? OzelKod7 { get; set; }
        public double? OzelKod8 { get; set; }
        public double? OzelKod9 { get; set; }
        public DateTime? OzelKod10 { get; set; }
        public DateTime? OzelKod11 { get; set; }
        public DateTime? OzelKod12 { get; set; }
        public byte? Izin { get; set; }
        public int? Renk1 { get; set; }
        public int? Renk2 { get; set; }

    }
}
