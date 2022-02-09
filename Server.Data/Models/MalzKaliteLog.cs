using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class MalzKaliteLog
    {
        public int Logref { get; set; }
        public int Malzemeref { get; set; }
        public string Tip { get; set; }
        public string Aciklama { get; set; }
        public string Metin { get; set; }
        public string Acik { get; set; }
        public string AcikIng { get; set; }
        public string Teknik { get; set; }
        public string TeknikIng { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public int Recref { get; set; }
    }
}
