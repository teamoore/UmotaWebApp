using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class CariKart
    {
        public int Logref { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Adi2 { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public int? Semtref { get; set; }
        public string Semt { get; set; }
        public int? Ilceref { get; set; }
        public string Ilce { get; set; }
        public int? Ilref { get; set; }
        public string Il { get; set; }
        public int? Ulkeref { get; set; }
        public string Ulke { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Faks { get; set; }
        public string Mail { get; set; }
        public string Web { get; set; }
        public string Vdno { get; set; }
        public string Vdadi { get; set; }
        public short? Sahismi { get; set; }
        public string Postakodu { get; set; }
        public string Ozelkod { get; set; }
        public string Ozelkod2 { get; set; }
        public string Ozelkod3 { get; set; }
        public string Ozelkod4 { get; set; }
        public string Ozelkod5 { get; set; }
        public int? Logoref { get; set; }
        public string Nakliye { get; set; }
        public string Nakliyeodeme { get; set; }
        public int? Odmplnref { get; set; }
        public byte? Active { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
