using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class DovizKuruRequestDto
    {
        public DateTime KurTarihi { get; set; }
        public int DovizTuru { get; set; }
        public short KurTuru { get; set; }
        public int LogoFirmaNo { get; set; }
    }
}
