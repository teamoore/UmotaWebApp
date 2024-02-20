﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Model
{
    public class Siparis : BaseEntity
    {
        #region Alanlar

        public string FisNo { get; private set; }
        public DateTime Tarih { get; private set; }
        public DateTime Saat { get; private set; }
        public int CariRef { get; private set; }
        public int ProjeRef { get; private set; }
        public int DurumRef { get; private set; }
        public int? LgFirmaNo { get; private set; }
        public int DovizRefID { get; private set; }
        public int DovizRefRD { get; private set; }
        public byte DovizKurTurID { get; set; }
        public double DovizKuruID { get; private set; }
        public double DovizKuruRD { get; private set; }
        public double NetToplamID { get; private set; }
        public double NetToplamRD { get; private set; }
        public double NetToplamTL { get; private set; }
        public byte DosyaEki { get; set; }
        public byte Iptal { get; set; }
        public string? IptalUser { get; set; }
        public DateTime? IptalDate { get; set; }
        public string? IptalNedeni { get; set; }

        #endregion
        public Siparis() { }
    }
}
