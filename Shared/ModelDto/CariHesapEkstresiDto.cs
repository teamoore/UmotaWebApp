using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class CariHesapEkstresiDto
    {
        public DateTime? tarih { get; set; }
        public string fisturadi { get; set; }
        public string belgeno { get; set; }
        public string aciklama { get; set; }
        public string dovizkodu { get; set; }
        public double? dovizkuru { get; set; }
        public double? doviztutar { get; set; }
        public double? borctut { get; set; }
        public double? alacaktut { get; set; }
        public double? bakiye { get; set; }
        public string bakod { get; set; }
        public string doviztutarFormatted
        {
            get
            {
                return this.doviztutar.HasValue ? String.Format("{0:N2}", this.doviztutar.Value) : "";
            }
        }
        public string borctutFormatted
        {
            get
            {
                return this.borctut.HasValue ? String.Format("{0:N2}", this.borctut.Value) : "";
            }
        }
        public string alacaktutFormatted
        {
            get
            {
                return this.alacaktut.HasValue ? String.Format("{0:N2}", this.alacaktut.Value) : "";
            }
        }
        public string bakiyeFormatted
        {
            get
            {
                return this.bakiye.HasValue ? String.Format("{0:N2}", this.bakiye.Value) : "";
            }
        }
        public string tarihFormatted
        {
            get
            {
                return this.tarih.HasValue ? this.tarih.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
    }
}
