using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class FaaliyetRequestDto
    {
        public string Aranacak{ get; set; }
        public short FirmaId { get; set; }
        public FaaliyetDto Faaliyet { get; set; }
    }
}
