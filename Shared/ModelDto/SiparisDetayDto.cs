using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SiparisDetayDto
    {
        public int Logref { get; set; }

        public int? Parlogref { get; set; }

        public double? Sirano { get; set; }

        public int? Mahal1ref { get; set; }

        public int? Mahal2ref { get; set; }

        public int? Mahal3ref { get; set; }

        public int? Mahal4ref { get; set; }

        public int? Mahal5ref { get; set; }

        public int? Kaynakref { get; set; }

        public int? Aktivite1ref { get; set; }

        public int? Aktivite2ref { get; set; }

        public int? Aktivite3ref { get; set; }

        public int? Aktivite4ref { get; set; }

        public int? Aktivite5ref { get; set; }

        public double? Miktar { get; set; }

        public int? Birimref { get; set; }

        public string Aciklama { get; set; }

        public int? Teslimyeriref { get; set; }

        public DateTime? Teslimtarihi { get; set; }

        public byte? Status { get; set; }

        public string Insuser { get; set; }

        public DateTime? Insdate { get; set; }

        public string Upduser { get; set; }

        public DateTime? Upddate { get; set; }

        public int? TalepRef { get; private set; }
        public int? TalepDetayRef { get; private set; }
        public double? Fiyat { get; private set; }
        public int? FDovizRef { get; private set; }
        public double? FDovizKuru { get; private set; }
        public double? Tutar { get; private set; }
        public double? TutarTL { get; private set; }
        public double? TutarRD { get; private set; }
        public double? TutarID { get; private set; }
        public double? IskYuz { get; private set; }
        public double? IskTut { get; private set; }
        public double? IskTutTL { get; private set; }
        public double? IskTutRD { get; private set; }
        public double? IskTutID { get; private set; }
        public byte KdvKod { get; set; }
        public double? KdvYuz { get; private set; }
        public double? KdvTut { get; private set; }
        public double? KdvTutTL { get; private set; }
        public double? KdvTutRD { get; private set; }
        public double? KdvTutID { get; private set; }
        public double? TutarNet { get; private set; }
        public double? TutarNetTL { get; private set; }
        public double? TutarNetRD { get; private set; }
        public double? TutarNetID { get; private set; }
        public double SevkMiktar { get; private set; }
        public double KalanMiktar { get; private set; }
        public double TalepBirimMiktar { get; private set; }
        public byte TalepMiktarFarki { get; set; }

        public string Mahal1kodu { get; set; }

        public string Mahal1adi { get; set; }

        public string Mahal2kodu { get; set; }

        public string Mahal2adi { get; set; }

        public string Mahal3kodu { get; set; }

        public string Mahal3adi { get; set; }

        public string Mahal4kodu { get; set; }

        public string Mahal4adi { get; set; }

        public string Mahal5kodu { get; set; }

        public string Mahal5adi { get; set; }

        public string Kaynakkodu { get; set; }

        public string Kaynakadi { get; set; }

        public string Aktivite1kodu { get; set; }

        public string Aktivite1adi { get; set; }

        public string Aktivite2kodu { get; set; }

        public string Aktivite2adi { get; set; }

        public string Aktivite3kodu { get; set; }

        public string Aktivite3adi { get; set; }

        public string Aktivite4kodu { get; set; }

        public string Aktivite4adi { get; set; }

        public string Aktivite5kodu { get; set; }

        public string Aktivite5adi { get; set; }

        public string Birimkodu { get; set; }

        public string Birimadi { get; set; }

        public string Teslimyeriadi { get; set; }

        public SiparisDetayDto() { }
    }
}
