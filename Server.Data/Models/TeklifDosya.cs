using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifDosya
    {
        public int Logref { get; set; }
        public int? Parlogref { get; set; }
        public byte[] Idata { get; set; }
        public string Itype { get; set; }
        public string Ifilename { get; set; }
        public string Ifilepath { get; set; }
        public int? Ifilesizekb { get; set; }
        public int? Ifilesizekbzip { get; set; }
        public DateTime? Ifiledate { get; set; }
        public string Aciklama { get; set; }
        public string Grup { get; set; }
        public int? TeklifRotaLogref { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
