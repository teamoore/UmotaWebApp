using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SiparisDto
    {
        public int logref { get; set; }
        public byte status { get; set; }

        public string? insuser { get; set; }
        public DateTime? insdate { get; set; }
        public string? upduser { get; set; }
        public DateTime? upddate { get; set; }
        public string FisNo { get;  set; }
        public DateTime Tarih { get;  set; }
        public DateTime Saat { get;  set; }
        public int CariRef { get;  set; }
        public int ProjeRef { get;  set; }
        public int DurumRef { get;  set; }
        public string? Aciklama { get;  set; }
        public int? LgFirmaNo { get;  set; }
        public int DovizRefID { get;  set; }
        public int DovizRefRD { get;  set; }
        public double DovizKuruID { get;  set; }
        public double DovizKuruRD { get;  set; }
        public double NetToplamID { get;  set; }
        public double NetToplamRD { get;  set; }
        public double NetToplamTL { get;  set; }

        public SiparisDto() { }
    }
}
