using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.Enum
{
    public class SharedEnums
    {
        public enum TeklifPdfType
        {
            Iskontolu = 0,
            Net = 1,
            NetKdv = 2
        }

        public enum TalepFisDurum
        {
            Oneri = 180,
            OnaySurecinde = 181,
            Onaylandi = 182,
            Karsilaniyor = 183,
            Karsilandi = 184
        }
    }
}
