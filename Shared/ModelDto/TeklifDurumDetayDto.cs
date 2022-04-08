using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TeklifDurumDetayDto
    {
        public int Refid { get; set; }
        public int? Teklifref { get; set; }
        public DateTime? Tarih { get; set; }
        public string Duruminfo { get; set; }
        public string Aciklama { get; set; }
        public string KullaniciKodu { get; set; }

    }
}
