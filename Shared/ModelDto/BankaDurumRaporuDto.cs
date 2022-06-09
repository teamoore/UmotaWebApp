using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class BankaDurumRaporuDto
    {
        public string bankakodu { get; set; }
        public string bankaadi { get; set; }
        public string bankasube { get; set; }
        public double? tl { get; set; }
        public double? usd { get; set; }
        public double? eur { get; set; }
        public double? chf { get; set; }
        public double? tahsilcekleri { get; set; }
        public double? teminatcekleri { get; set; }
        public double? temsnkr_nakit { get; set; }
        public double? temsnkr_taksit { get; set; }
        public double? temsnkr_arac { get; set; }
        public double? temsnkr_ipotek { get; set; }
        public double? temsnkr_iskonto { get; set; }
        public string tlFormatted
        {
            get
            {
                return this.tl.HasValue ? String.Format("{0:N2}", this.tl.Value) : "";
            }
        }
        public string eurFormatted
        {
            get
            {
                return this.eur.HasValue ? String.Format("{0:N2}", this.eur.Value) : "";
            }
        }
        public string usdFormatted
        {
            get
            {
                return this.usd.HasValue ? String.Format("{0:N2}", this.usd.Value) : "";
            }
        }
        public string chfFormatted
        {
            get
            {
                return this.chf.HasValue ? String.Format("{0:N2}", this.chf.Value) : "";
            }
        }
        public string tahsilcekleriFormatted
        {
            get
            {
                return this.tahsilcekleri.HasValue ? String.Format("{0:N2}", this.tahsilcekleri.Value) : "";
            }
        }
        public string teminatcekleriFormatted
        {
            get
            {
                return this.teminatcekleri.HasValue ? String.Format("{0:N2}", this.teminatcekleri.Value) : "";
            }
        }
        public string temsnkr_nakitFormatted
        {
            get
            {
                return this.temsnkr_nakit.HasValue ? String.Format("{0:N2}", this.temsnkr_nakit.Value) : "";
            }
        }
        public string temsnkr_taksitFormatted
        {
            get
            {
                return this.temsnkr_taksit.HasValue ? String.Format("{0:N2}", this.temsnkr_taksit.Value) : "";
            }
        }
        public string temsnkr_aracFormatted
        {
            get
            {
                return this.temsnkr_arac.HasValue ? String.Format("{0:N2}", this.temsnkr_arac.Value) : "";
            }
        }
        public string temsnkr_ipotekFormatted
        {
            get
            {
                return this.temsnkr_ipotek.HasValue ? String.Format("{0:N2}", this.temsnkr_ipotek.Value) : "";
            }
        }
        public string temsnkr_iskontoFormatted
        {
            get
            {
                return this.temsnkr_iskonto.HasValue ? String.Format("{0:N2}", this.temsnkr_iskonto.Value) : "";
            }
        }
    }
}
