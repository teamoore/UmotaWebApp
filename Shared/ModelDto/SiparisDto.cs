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
        public byte? DosyaEki { get; set; }
        public int? LgFirmaNo { get;  set; }
        public int DovizRefID { get;  set; }
        public int DovizRefRD { get;  set; }
        public byte DovizKurTurID { get; set; }
        public double DovizKuruID { get;  set; }
        public double DovizKuruRD { get;  set; }
        public double NetToplamID { get;  set; }
        public double NetToplamRD { get;  set; }
        public double NetToplamTL { get;  set; }
        public byte Iptal { get; set; }
        public string? IptalUser { get; set; }
        public DateTime? IptalDate { get; set; }
        public string? IptalNedeni { get; set; }
        public int? DurumiKodu { get; set; }
        public string? DurumAdi { get; set; }
        public int? Renk1 { get; set; }
        public int? Renk2 { get; set; }
        public string? ProjeKodu { get; set; }
        public string? ProjeAdi { get; set; }
        public int? ProjeSirketRef { get; set; }
        public string? ProjeSirketKodu { get; set; }
        public string? ProjeSirketAdi { get; set; }
        public string? CariKodu { get; set; }
        public string? CariAdi { get; set; }
        public string? DovizKoduRD { get; set; }
        public string? DovizKoduID { get; set; }

        private string _tarihString = "";
        public string TarihString
        {
            get
            {
                return this.Tarih.ToString("dd.MM.yyyy");
            }
            set { this._tarihString = value; }
        }

        private string _saatString = "";
        public string SaatString
        {
            get
            {
                return this.Saat.ToString("HH:mm");
            }
            set { this._saatString = value; }
        }

        public SiparisDto() { }
    }
}
