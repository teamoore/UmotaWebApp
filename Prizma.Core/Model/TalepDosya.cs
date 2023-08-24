namespace Prizma.Core.Model
{
    public class TalepDosya : BaseEntity
    {
        public int TalepLogRef { get; private set; }
        public string DosyaAdi { get; private set; }
        public string DosyaTipi { get; private set; }

        private TalepDosya()
        {
            
        }

        public static TalepDosya Create(string adi,string tipi,int talepLogRef,string insuser)
        {
            var td = new TalepDosya();
            td.insdate = DateTime.Now;
            td.insuser = insuser;
            td.DosyaAdi = adi;
            td.DosyaTipi = tipi;
            td.TalepLogRef = talepLogRef;

            return td;
        }

    }
}
