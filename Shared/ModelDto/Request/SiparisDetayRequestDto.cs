using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class SiparisDetayRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public int TopRowCount { get; set; }
        public V041_SiparisDetay SiparisDetay { get; set; }
    }
}
