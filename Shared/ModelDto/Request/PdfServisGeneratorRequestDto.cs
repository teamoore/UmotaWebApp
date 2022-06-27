using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class PdfServisGeneratorRequestDto
    {
        public string Kullanici { get; set; }
        public short FirmaId { get; set; }
        public ServisDto Servis { get; set; }
    }
}
