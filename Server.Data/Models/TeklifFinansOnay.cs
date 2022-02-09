using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifFinansOnay
    {
        public int Logref { get; set; }
        public double? Bas { get; set; }
        public double? Bit { get; set; }
        public string Onay1 { get; set; }
        public string Onay2 { get; set; }
        public string Onay3 { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
