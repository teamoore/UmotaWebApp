using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepFisRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public string SearchText { get; set; }
        public int TopRowCount { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarih { get; set; }
        public int? ProjeRef { get; set; }
        public int? TurRef { get; set; }
        public int? DurumRef { get; set; }
        public string DurumIKoduSecimList { get; set; }
        public bool OnayBekleyen { get; set; }
        public bool TumTalepleriGormeYetkisi { get; set; }
        public string SQLStringOrderBy { get; set; }
        public TalepFisDto TalepFis { get; set; }

    }
}
