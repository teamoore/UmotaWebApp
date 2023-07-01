namespace UmotaWebApp.Server.Domain
{
    public class Mahal
    {
        public Proje Proje { get; private set; }
        public string Kodu { get; private set; }

        public string Adi { get; set; }

        public Mahal(string kodu,string adi)
        {
            this.Kodu = kodu;
            this.Adi = adi;
        }

        public void SetProje(Proje proje)
        {
            this.Proje = proje;
        }
    }
}
