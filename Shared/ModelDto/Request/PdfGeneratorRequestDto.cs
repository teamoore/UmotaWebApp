using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.Enum;

namespace UmotaWebApp.Shared.ModelDto
{
    public class PdfGeneratorRequestDto
    {
        public TeklifDto teklif { get; set; }
        public List<TeklifDetayDto> teklifDetays { get; set; }
        public SharedEnums.TeklifPdfType PdfType { get; set; }
        public string Kullanici { get; set; }
        public short FirmaId { get; set; }
    }
}
