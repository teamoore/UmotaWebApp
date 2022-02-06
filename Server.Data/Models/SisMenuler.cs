using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisMenuler
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public short MenuModul { get; set; }
        public string MenuSecenek { get; set; }
        public string MenuTanimi { get; set; }
        public string MenuDfm { get; set; }
        public short? MenuSira { get; set; }
        public bool? MenuGirismi { get; set; }
        public short? MenuParam { get; set; }
        public bool? MenuAcarkenGuncelle { get; set; }
        public short? ImageIndex { get; set; }
    }
}
