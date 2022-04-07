using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class VMalzemeKartDto
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
        public int? Birimref { get; set; }
        public string Birimkodu { get; set; }
        public double? Alfiyat { get; set; }
        public string AlfiyatDov { get; set; }
        public double? Satfiyat { get; set; }
        public string SatfiyatDov { get; set; }
    }
}
