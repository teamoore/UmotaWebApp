using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifDosyaPathLog
    {
        public int Recref { get; set; }
        public int Logref { get; set; }
        public int? Parlogref { get; set; }
        public string Filename { get; set; }
        public string Aciklama { get; set; }
        public string Grup { get; set; }
        public int? TeklifRotaLogref { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
