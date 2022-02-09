using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V050MalzKalite
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
        public string Malzemekodu { get; set; }
        public string Malzemeadi { get; set; }
        public string Malzememarkaadi { get; set; }
        public string Malzememensei { get; set; }
        public string Grupkodu { get; set; }
        public string Ozelkod2 { get; set; }
        public string Malzemeebat { get; set; }
    }
}
