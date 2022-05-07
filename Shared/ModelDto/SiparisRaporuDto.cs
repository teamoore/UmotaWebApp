using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SiparisRaporuDto
    {
        public DateTime? siparistarihi { get; set; }
        public string siparisno { get; set; }
        public string siparisbelgeno { get; set; }
        public double? miktar { get; set; }
        public double? kalanmiktar { get; set; }
        public double? bekleyentutar { get; set; }
        public string carikodu { get; set; }
        public string caritanim { get; set; }
        public string malzkodu { get; set; }
        public string malztanim { get; set; }
        public string satici { get; set; }
        public string cariozelkod3 { get; set; }
        public string cariozelkod3aciklama { get; set; }
        public DateTime? teslimattarihi { get; set; }
        public int gecensure { get; set; }
        public string satiraciklamasi { get; set; }
        public string siparisaciklama1 { get; set; }
        public string siparisaciklama2 { get; set; }
        public string ili { get; set; }
        public string ilcesi { get; set; }
        public string onay { get; set; }
        public string marka { get; set; }
        public int teslimatay { get; set; }
        public double? stokmik { get; set; }
        public double? rezerv { get; set; }
        public double? stokmikariza { get; set; }
        public double? stokmikshow { get; set; }
        public double? stokmik2el { get; set; }

        public string bekleyentutarFormatted
        {
            get
            {
                return this.bekleyentutar.HasValue ? String.Format("{0:N2}", this.bekleyentutar.Value) : "";
            }
        }

        public string siparistarihiFormatted
        {
            get
            {
                return this.siparistarihi.HasValue ? this.siparistarihi.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
        public string teslimattarihiFormatted
        {
            get
            {
                return this.teslimattarihi.HasValue ? this.teslimattarihi.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
    }
}
