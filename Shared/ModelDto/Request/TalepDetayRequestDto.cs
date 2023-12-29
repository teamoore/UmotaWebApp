using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepDetayRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }

        public string SearchText { get; set; }
        public int TopRowCount { get; set; }

        public TalepDetayDTO TalepDetay { get; set; }
    }
}
