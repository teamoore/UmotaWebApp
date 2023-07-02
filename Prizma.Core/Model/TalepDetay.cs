
using System.ComponentModel.DataAnnotations.Schema;

namespace Prizma.Core.Model
{
    public class TalepDetay : BaseEntity
    {
        private TalepDetay()
        {
                
        }

        public string Aciklama { get; private set; }
        public double Miktar { get; private set; }
        public int BirimRef { get; private set; }
        public int mahal1ref { get; private set; }
        public int mahal2ref { get; private set; }
        public int mahal3ref { get; private set; }
        public int mahal4ref { get; private set; }
        public int mahal5ref { get; private set; }

        public static TalepDetay Create(string aciklama,double miktar, int birimRef) 
        {
            if (string.IsNullOrEmpty(aciklama))
                throw new ArgumentNullException(nameof(aciklama));

            if (miktar <= 0)
                throw new ArgumentOutOfRangeException(nameof(miktar));

            if (birimRef <= 0)
                throw new ArgumentOutOfRangeException(nameof(birimRef));

            return new TalepDetay
            {
                Aciklama = aciklama,
                Miktar = miktar,
                BirimRef = birimRef
            };
        }

    }
}
