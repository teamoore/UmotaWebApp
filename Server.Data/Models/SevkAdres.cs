using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SevkAdres
    {
        public int Logref { get; set; }
        public string Sevkkodu { get; set; }
        public string SevkEdilecekBayiAdi { get; set; }
        public string Sevkadres1 { get; set; }
        public string Sevkadres2 { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        public string Ulke { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Mail { get; set; }
        public string Postakodu { get; set; }
        public int? Clientref { get; set; }
        public string? SevkIlgilisi { get; set; }
        public byte? Active { get; set; }
        public byte? Status { get; set; }
        public string? Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string? Upduser { get; set; }
        public DateTime? Upddate { get; set; }

    }
}
