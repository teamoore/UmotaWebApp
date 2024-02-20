using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepDosyaDto
    {
        public int LogRef { get; set; }
        public int TalepLogRef { get; set; }
        public string DosyaAdi { get; set; }
        public string DosyaTipi { get; set; }
        public string InsUser { get; set; }

        public TalepDosyaDto()
        {
            
        }
    }
}
