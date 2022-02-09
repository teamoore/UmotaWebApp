using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class TeklifRotaLog
    {
        public int Recref { get; set; }
        public int Logref { get; set; }
        public int? Teklifref { get; set; }
        public int? Operasyonref { get; set; }
        public string Opkodu { get; set; }
        public string Opadi { get; set; }
        public int? Opharturref { get; set; }
        public string Optanim { get; set; }
        public short Opsira { get; set; }
        public string Opozelkod { get; set; }
        public bool? Opfason { get; set; }
        public DateTime? Opbitistarihi { get; set; }
        public string Istekler { get; set; }
        public string Yapilanlar { get; set; }
        public string Kisiler { get; set; }
        public DateTime? TalepTarihi { get; set; }
        public int? Irsref { get; set; }
        public byte? Durum { get; set; }
        public string IsinAdi { get; set; }
        public byte? TasarimGordu { get; set; }
        public int? OncelikSirasi { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
