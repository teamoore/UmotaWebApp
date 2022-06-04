using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Data.Models
{
    public partial class Vazife
    {
        public int Logref { get; set; }
        public string VazifeTipi { get; set; }
        public int? CariRef { get; set; }
        public string CariAdi { get; set; }
        public int? KisiRef { get; set; }
        public string AtananKisi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime? SonTarih { get; set; }
        public byte? Oncelik { get; set; }
        public byte? Yapildi { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitirmeTarihi { get; set; }
    }
}
