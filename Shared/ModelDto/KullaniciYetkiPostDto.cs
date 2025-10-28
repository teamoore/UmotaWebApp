using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class KullaniciYetkiPostDto
    {
        public string KullaniciKodu { get; set; }
        public List<KullaniciYetkiDto> YetkiKodlari { get; set; } = new();
    }
}
