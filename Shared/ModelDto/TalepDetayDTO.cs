using System;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepDetayDTO
    {
        public string Aciklama { get; set; }

        public double Miktar { get; set; }

        public int BirimRef { get; set; }

        public int logref { get; set; }
        public byte status { get; set; }

        public string? insuser { get; set; }
        public DateTime? insdate { get; set; }
        public string? upduser { get; set; }
        public DateTime? upddate { get; set; }

        public int mahal1ref { get; private set; }
        public int mahal2ref { get; private set; }
        public int mahal3ref { get; private set; }
        public int mahal4ref { get; private set; }
        public int mahal5ref { get; private set; }
    }
}
