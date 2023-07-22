using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepFisDto
    {
        public string FisNo { get;  set; }
        public DateTime Tarih { get;  set; }
        public DateTime Saat { get;  set; }
        public int TurRef { get; set; }
        public int ProjeRef { get;  set; }
        public string TalepEden { get;  set; }
        public DateTime TeslimTarihi { get;  set; }
        public byte DurumRef { get;  set; }
        public int Oncelik { get;  set; }
        public string? Aciklama { get;  set; }
        public int? LgFirmaNo { get;  set; }

        public int TeslimYeriRef { get; set; }

        public int logref { get; set; }
        public byte status { get; set; }

        public string? insuser { get; set; }
        public DateTime? insdate { get; set; }
        public string? upduser { get; set; }
        public DateTime? upddate { get; set; }
    }
}
