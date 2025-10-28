using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class KullaniciMenuYetkiPostDto
    {
        public string KullaniciKodu { get; set; }
        public List<KullaniciMenuYetkiDto> Menuler { get; set; } = new();

    }
}
