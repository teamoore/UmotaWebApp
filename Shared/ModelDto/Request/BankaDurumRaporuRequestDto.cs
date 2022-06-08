using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class BankaDurumRaporuRequestDto
    {
        public int LogoFirmaNo { get; set; }
        public int LogoDonemNo { get; set; }
        public DateTime? RaporTarihi { get; set; }
    }
}
