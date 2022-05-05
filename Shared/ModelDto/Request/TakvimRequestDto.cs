using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TakvimRequestDto
    {
        public string User { get; set; }
        public short FirmaId { get; set; }

        public TakvimDto Takvim { get; set; }
    }
}
