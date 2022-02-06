using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisMenuProfilHaklari
    {
        public int ProfilId { get; set; }
        public int MenuId { get; set; }
        public string HakTipi { get; set; }
    }
}
