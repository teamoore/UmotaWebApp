﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SiparisRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public string SearchTextSatir { get; set; }
        public int TopRowCount { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public int? ProjeRef { get; set; }
        public int? CariRef { get; set; }
        public string CariAdi { get; set; }
        public int? DurumRef { get; set; }
        public string DurumIKoduSecimList { get; set; }
        public bool OnayBekleyen { get; set; }
        public bool TumSiparisleriGormeYetkisi { get; set; }
        public string SQLStringOrderBy { get; set; }
        public SiparisDto SiparisDto { get; set; }
     
    }
}