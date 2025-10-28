using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class KullaniciMenuYetkiDto
    {
        public string KullaniciKodu { get; set; } = string.Empty;
        public int MenuID { get; set; }
        public string YetkiTuru { get; set; } = "sel";

    }
}
