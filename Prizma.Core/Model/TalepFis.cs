using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmotaWebApp.Shared.Enum.SharedEnums;

namespace Prizma.Core.Model
{
    public class TalepFis : BaseEntity
    {
        #region Alanlar

        public string FisNo { get; private set; }
        public DateTime Tarih { get; private set; }
        public DateTime Saat { get; private set; }
        public int TurRef { get; private set; }
        public int ProjeRef { get; private set; }
        public string TalepEden { get; private set; }
        public DateTime TeslimTarihi { get; private set; }
        public byte DurumRef { get; private set; }
        public int Oncelik { get; private set; }
        public string? Aciklama { get; private set; }
        public int? LgFirmaNo { get; private set; }
        public int TeslimYeriRef { get; private set; }

        #endregion

        private static TalepFis _talepFis = new TalepFis() { FisNo = "000", Tarih = DateTime.Now, Saat = DateTime.Now, TurRef = 188, Aciklama = "", DurumRef = (byte)TalepFisDurum.Oneri, Oncelik = 1, TalepEden = "Umota", insdate = DateTime.Now, insuser = "Umota", TeslimTarihi = DateTime.Now.AddDays(3), TeslimYeriRef = 187 };

        private TalepFis()
        {
            
        }

        public static TalepFis Create(int logref, int? tur, int? proje, string talepEden)
        {
            TalepFis yeniTalepFis = (TalepFis)_talepFis.MemberwiseClone();
            yeniTalepFis.TalepEden = talepEden;
            yeniTalepFis.TurRef = tur.HasValue ? tur.Value : 0;
            yeniTalepFis.ProjeRef = proje.HasValue ? proje.Value : 0;
            yeniTalepFis.logref = logref;

            return yeniTalepFis;
        }

        public void ChangeDurum(TalepFisDurum durum)
        {
            this.DurumRef = (byte)durum;
        }
        
        public void ChangeTeslimatBilgileri(int teslimYeri, DateTime teslimTarihi)
        {
            this.TeslimYeriRef = teslimYeri;
            this.TeslimTarihi = teslimTarihi;
        }

        public void ChangeAciklama(string aciklama)
        {
            this.Aciklama = aciklama;
        }
        
        
    }
}
