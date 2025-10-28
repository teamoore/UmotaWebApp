using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class ProjeDetayRaporuReq
    {
        public int FirmNr { get; set; }
        public int FirmNr2 { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeOzelKod { get; set; }
        public int GelirGider { get; set; }

    }
}
