using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TahsilatRaporuDto
    {
        public string carikodu { get; set; }
        public string cariadi { get; set; }
        public string cariozelkod2 { get; set; }
        public int cariref { get; set; }
        public string tranno { get; set; }
        public int saticiref { get; set; }
        public string saticiadi { get; set; }
        public DateTime? tarih { get; set; }
        public int yil { get; set; }
        public int ay { get; set; }
        public int gun { get; set; }
        public double? nakit { get; set; }
        public double? nakit_i { get; set; }
        public double? havale { get; set; }
        public double? havale_i { get; set; }
        public double? cek { get; set; }
        public double? cek_i { get; set; }
        public double? senet { get; set; }
        public double? senet_i { get; set; }
        public double? kredikart { get; set; }
        public double? kredikart_i { get; set; }
        public double? virman { get; set; }
        public double? toplam
        {
            get
            {
                return this.nakit + this.havale + this.cek + this.senet + this.kredikart + this.virman - this.nakit_i - this.havale_i - this.cek_i - this.senet_i - this.kredikart_i;
            }
        }
        public string toplamFormatted
        {
            get
            {
                return this.toplam.HasValue ? String.Format("{0:N2}", this.toplam.Value) : "";
            }
        }

        public string tarihFormatted
        {
            get
            {
                return this.tarih.HasValue ? this.tarih.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
        public string nakitFormatted
        {
            get
            {
                return this.nakit.HasValue ? String.Format("{0:N2}", this.nakit.Value) : "";
            }
        }
        public string nakit_iFormatted
        {
            get
            {
                return this.nakit_i.HasValue ? String.Format("{0:N2}", this.nakit_i.Value) : "";
            }
        }
        public string havaleFormatted
        {
            get
            {
                return this.havale.HasValue ? String.Format("{0:N2}", this.havale.Value) : "";
            }
        }
        public string havale_iFormatted
        {
            get
            {
                return this.havale_i.HasValue ? String.Format("{0:N2}", this.havale_i.Value) : "";
            }
        }
        public string cekFormatted
        {
            get
            {
                return this.cek.HasValue ? String.Format("{0:N2}", this.cek.Value) : "";
            }
        }
        public string cek_iFormatted
        {
            get
            {
                return this.cek_i.HasValue ? String.Format("{0:N2}", this.cek_i.Value) : "";
            }
        }
        public string senetFormatted
        {
            get
            {
                return this.senet.HasValue ? String.Format("{0:N2}", this.senet.Value) : "";
            }
        }
        public string senet_iFormatted
        {
            get
            {
                return this.senet_i.HasValue ? String.Format("{0:N2}", this.senet_i.Value) : "";
            }
        }
        public string kredikartFormatted
        {
            get
            {
                return this.kredikart.HasValue ? String.Format("{0:N2}", this.kredikart.Value) : "";
            }
        }
        public string kredikart_iFormatted
        {
            get
            {
                return this.kredikart_i.HasValue ? String.Format("{0:N2}", this.kredikart_i.Value) : "";
            }
        }
        public string virmanFormatted
        {
            get
            {
                return this.virman.HasValue ? String.Format("{0:N2}", this.virman.Value) : "";
            }
        }
    }
}
