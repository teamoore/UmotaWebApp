using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared
{
    public class V002_Kaynak
    {
        public int Logref { get; set; }

        public int Parlogref { get; set; }

        public string Kodu { get; set; }

        public string Adi { get; set; }

        public byte? Seviye { get; set; }

        public string Uzunkodu { get; set; }

        public string Uzunadi { get; set; }

        public int Aktiviteref { get; set; }

        public byte? active { get; set; }

        public int? status { get; set; }

        public string insuser { get; set; }

        public DateTime? insdate { get; set; }

        public string upduser { get; set; }

        public DateTime? upddate { get; set; }

        public double? Kdvyuz { get; set; }

        public string Aktivitekodu { get; set; }

        public string Aktiviteadi { get; set; }

        public string Aktiviteuzunadi { get; set; }

        public string Aktivitekoduadi { get; set; }

        public int? Aktiviteref2 { get; set; }

        public string Aktivitekodu2 { get; set; }

        public string Aktiviteadi2 { get; set; }

        public string Aktivitekoduadi2 { get; set; }

        public int? Aktiviteref3 { get; set; }

        public string Aktivitekodu3 { get; set; }

        public string Aktiviteadi3 { get; set; }

        public string Aktivitekoduadi3 { get; set; }
    }

}
