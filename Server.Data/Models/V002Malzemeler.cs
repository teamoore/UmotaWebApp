﻿using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class V002Malzemeler
    {
        public int Logref { get; set; }
        public int? Karttipi { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Adi3 { get; set; }
        public string Grupkodu { get; set; }
        public string Ozelkod { get; set; }
        public string Ozelkod2 { get; set; }
        public string Ozelkod3 { get; set; }
        public string Ozelkod4 { get; set; }
        public string Ozelkod5 { get; set; }
        public short? Active { get; set; }
        public double? Kdvyuz { get; set; }
        public string Descr { get; set; }
        public string Definition { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public string Ebatt { get; set; }
        public int? Birimsetiref { get; set; }
    }
}