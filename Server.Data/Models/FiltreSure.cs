using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class FiltreSure
    {
        public int Logref { get; set; }
        public int? LstokId { get; set; }
        public string LstokKodu { get; set; }
        public string LstokAdi { get; set; }
        public string Aciklama { get; set; }
        public string TekrarlamaSekli { get; set; }
        public int? TekrarlamaSuresi { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
