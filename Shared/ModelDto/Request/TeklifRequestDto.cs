﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TeklifRequestDto
    {
        public TeklifDto Teklif { get; set; }
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public int? Dovizrefid { get; set; }
        public int? Personelref { get; set; }
        public string Proje { get; set; }
        public string Cariadi { get; set; }
        public int? Revizyon { get; set; }
        public string Duruminfo { get; set; }
        public string insuser { get; set; }
        public int TopRowCount { get; set; }
    }
}
