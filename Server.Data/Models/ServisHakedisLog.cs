using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class ServisHakedisLog
    {
        public int Logref { get; set; }
        public int Servisref { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime? Fattar { get; set; }
        public string Fatno { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public int Recref { get; set; }
        public double? Tutar { get; set; }
        public string Odemedurumu { get; set; }
        public string Hno { get; set; }
        public bool? Mailgittimi { get; set; }
        public DateTime? Mailtar { get; set; }
    }
}
