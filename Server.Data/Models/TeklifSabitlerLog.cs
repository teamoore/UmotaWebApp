using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifSabitlerLog
    {
        public int? Logref { get; set; }
        public double? Isk1 { get; set; }
        public double? Isk2 { get; set; }
        public double? Isk3 { get; set; }
        public double? Isk { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public int Recref { get; set; }
    }
}
