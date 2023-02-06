using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeStokRequestDto
    {
        public int UmotaFirmaNo { get; set; }
        public int LogoFirmaNo { get; set; }
        public int LogoDonemNo { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string MalzemeMarka { get; set; }
        public int TopRowCount { get; set; }
        public string HeaderText { get; set; }
        public int UmotaKartlariGetir { get; set; }
        public bool YedekParcaGelsin { get; set; }
    }
}
