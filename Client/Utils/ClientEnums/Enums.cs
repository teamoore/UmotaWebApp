using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils.ClientEnums
{
    public class Enums
    {
        public enum MalzemeDetayliArama
        {
            Genel = 0,
            Marka = 1,
            Adi = 2
        }
        public enum KullaniciMenuProfil
        {
            Satis = 3
        }
        public enum OnayDurumu
        {
            Bekliyor = 1,
            Onaylandi = 3,
            GeriGonderildi = 4,
            Iptal = 5
        }
        public enum TalepDurumu
        {
            Oneri = 1,
            OnaySurecinde = 2,
            Onaylandi = 3,
            Karsilaniyor = 4,
            Karsilandi = 5,
            Iptal = 6,
            GeriGonderildi = 7
        }
        public enum OrderBy
        {
            Ascending = 1,
            Descending = 2
        }
    }
}
