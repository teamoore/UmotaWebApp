using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class CariDurumRaporuDto
    {
        public int cariref { get; set; }
        public string carikodu { get; set; }
        public string cariadi { get; set; }
        public string carigrup { get; set; }
        public string specode3 { get; set; }
        public string specode3adi { get; set; }
        public string specode4 { get; set; }
        public double? bakiye { get; set; }
        public double? sonfattutar { get; set; }
        public DateTime? sonfattar { get; set; }
        public DateTime? ortalamavade { get; set; }
        public int ortalamagun { get; set; }
        public int kacgungecmis { get; set; }
        public string ortalamavadeFormatted
        {
            get
            {
                return this.ortalamavade.HasValue ? this.ortalamavade.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
        public string sonfattarFormatted
        {
            get
            {
                return this.sonfattar.HasValue ? this.sonfattar.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
        public string bakiyeFormatted
        {
            get
            {
                return this.bakiye.HasValue ? String.Format("{0:N2}", this.bakiye.Value) : "";
            }
        }
        public string sonfattutarFormatted
        {
            get
            {
                return this.sonfattutar.HasValue ? String.Format("{0:N2}", this.sonfattutar.Value) : "";
            }
        }
        public string caritel1 { get; set; }
        public string caritel2 { get; set; }
        public string carimail { get; set; }
    }
}
