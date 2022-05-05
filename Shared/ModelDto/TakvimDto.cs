using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TakvimDto
    {
        public int Logref { get; set; }

        public DateTime? Tarih { get; set; }

        public TimeSpan? Saat { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public int? CariRef { get; set; }
        public string Cari_Kodu { get; set; }
        public string Cari_Adi { get; set; }
        public byte? Yapildi { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }

        public DateTime? TarihEnd
        {
            get
            {
                return this.Tarih.HasValue ? this.Tarih.Value.AddHours(1) : null;
            }
        }
    }
}
