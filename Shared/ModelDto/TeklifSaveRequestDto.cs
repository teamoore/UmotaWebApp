using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TeklifSaveRequestDto
    {
        public TeklifDto Teklif { get; set; }
        public short FirmaId { get; set; }
    }
}
