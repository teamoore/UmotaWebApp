using System;
using System.Collections.Generic;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class SisRefno
    {
        public string Tablename { get; set; }
        public int Increment { get; set; }
        public int Lastrefno { get; set; }
    }
}
