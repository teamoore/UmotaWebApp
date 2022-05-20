using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class BaseRequestDto
    {
        public string User { get; set; }
        public short FirmaId { get; set; }
        public string SearchText { get; set; }
        public string KullaniciKodu { get; set; }
        public int TopRowCount { get; set; }
    }
}
