using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class PdfGeneratorRequestDto
    {
        public TeklifDto teklif { get; set; }
        public List<TeklifDetayDto> teklifDetays { get; set; }
    }
}
