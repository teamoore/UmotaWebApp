using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class KullaniciYetkiDto
    {
        public int ID { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public bool Secili { get; set; } // UI için
    }
}
