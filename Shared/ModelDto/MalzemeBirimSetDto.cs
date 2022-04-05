using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeBirimSetDto
    {
        public int BirimSetRef { get; set; }
        public string BirimSetKodu { get; set; }
        public int AnaBirimRef { get; set; }
        public string AnaBirimKodu { get; set; }
    }
}
