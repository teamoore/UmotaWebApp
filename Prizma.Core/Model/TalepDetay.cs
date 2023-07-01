 
namespace Prizma.Core.Model
{
    public class TalepDetay : BaseEntity
    { 
        public string Aciklama { get; private set; }
        public double Miktar { get; private set; }
        public int BirimRef { get; private set; }

        public TalepDetay(string aciklama,double miktar, int birimRef) 
        { 
            this.Aciklama = aciklama;
            this.Miktar = miktar;
            this.BirimRef = birimRef;
        }

    }
}
