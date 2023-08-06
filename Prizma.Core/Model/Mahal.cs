using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Model
{
    public class Mahal : BaseEntity
    {
        private Mahal()
        {
                
        }
        public int ProjeRef { get; private set; }
        public string? Kodu { get; private set; }
        public string Adi { get; private set; }
        public int? DurumRef { get; private set; }
        public byte? Active { get;  private set; }
        public int TurRef { get; private set; }

        public static Mahal Create(int logref, string kodu, string adi, int projeRef)
        {
            if (logref <= 0)
                throw new ArgumentOutOfRangeException(nameof(logref));

            if (string.IsNullOrEmpty(adi))
                throw new ArgumentNullException(nameof(adi));

            return new Mahal
            {
                logref = logref,
                Kodu = kodu,
                Adi = adi,
                ProjeRef = projeRef
            };
        }

    }
}
