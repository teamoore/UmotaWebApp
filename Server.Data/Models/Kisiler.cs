using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class Kisiler
    {
        public int Logref { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Tamadi { get; set; }
        public int? Cariref { get; set; }
        public string Cariadi { get; set; }
        public string Bolum { get; set; }
        public string Pozisyon { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Mail { get; set; }
        public string Evtel { get; set; }
        public string Istel { get; set; }
        public string Ceptel { get; set; }
        public string Digtel { get; set; }
        public string Faks { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public bool? Varsayilan { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
