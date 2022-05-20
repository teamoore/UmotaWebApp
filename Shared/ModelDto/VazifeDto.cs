using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class VazifeDto
    {
        public int Logref { get; set; }
        public string AtananKisi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime? SonTarih { get; set; }
        public byte? Oncelik { get; set; }
        public byte? Yapildi { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }

        private bool _yapildiMi = false;
        public bool YapildiMi
        {
            get
            {
                if (Yapildi.HasValue && Yapildi.Value == 1)
                    _yapildiMi = true;

                return _yapildiMi;
            }
            set
            {
                _yapildiMi = value;

                this.Yapildi = _yapildiMi ? byte.Parse("1") : byte.Parse("0");
            }
        }

        private string _oncelik = "";

        public string OncelikAciklama
        {
            get
            {
                switch (this.Oncelik)
                {
                    case 1:
                        _oncelik = "Düşük";
                        break;
                    case 2:
                        _oncelik = "Orta";
                        break;
                    case 3:
                        _oncelik = "Yüksek";
                        break;
                    default:
                        _oncelik = "Düşük";
                        break;
                }

                return _oncelik;
            }
        }

        private string _yapildiAciklama = "";
        public string YapildiAciklama
        {
            get
            {
                switch (this.Yapildi)
                {
                    case 1:
                        _yapildiAciklama = "Yapıldı";
                        break;
                    case 0:
                        _yapildiAciklama = "Yapılmadı";
                        break;
                    default:
                        _yapildiAciklama = "Yapılmadı";
                        break;
                }
                return _yapildiAciklama;
            }
        }
    }
}
