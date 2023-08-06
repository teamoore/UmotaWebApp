using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MahalDto
    {
        public int Logref { get; set; }

        public int? Projeref { get; set; }

        public int? Turref { get; set; }

        public string Kodu { get; set; }

        public string Adi { get; set; }

        public int? Durumref { get; set; }

        public byte? Active { get; set; }

        public int? Status { get; set; }

        public string Insuser { get; set; }

        public DateTime? Insdate { get; set; }

        public string Upduser { get; set; }

        public DateTime? Upddate { get; set; }
    }

}
