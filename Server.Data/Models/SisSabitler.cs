using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisSabitler
    {
        public short Tip { get; set; }
        public string Tanimi { get; set; }
        public byte? Izin { get; set; }
    }
}
