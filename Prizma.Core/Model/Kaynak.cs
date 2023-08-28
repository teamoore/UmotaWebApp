using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Model
{
    public class Kaynak
    {
        public int logref { get; set; }

        public int parlogref { get; set; }

        public int Aktiviteref { get; set; }
        public string Kodu { get; set; }

        public string Adi { get; set; }

        public byte? Seviye { get; set; }

        public string Uzunkodu { get; set; }

        public string Uzunadi { get; set; }

        public double? Kdvyuz { get; set; }
        public byte? active { get; set; }

        public int? status { get; set; }

        public string insuser { get; set; }

        public DateTime? insdate { get; set; }

        public string upduser { get; set; }

        public DateTime? upddate { get; set; }

        public Kaynak() { }
    }
}
