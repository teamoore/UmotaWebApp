using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class VazifeRequestDto
    {
        public string User { get; set; }
        public short FirmaId { get; set; }

        public VazifeDto Vazife { get; set; }
    }
}
