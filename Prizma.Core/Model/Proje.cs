using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Model
{
    public class Proje : BaseEntity
    {
        private static Proje _instance = new Proje() { Kodu = "000", Active = 0, Adi = "ProjeAdi", SirketRef = 1  };
        #region Alanlar

        public string Kodu { get; private set; }
        public string Adi { get; set; }
        public int SirketRef { get; set; }
        public byte Active { get; set; }

        #endregion

        private Proje()
        {
            
        }

        public static Proje Create(string kodu,string adi,int sirketRef)
        {
            var instance = (Proje)_instance.MemberwiseClone();
            instance.Kodu = kodu;
            instance.Adi = adi;
            instance.SirketRef = sirketRef;

            return instance;

        }

    }
}
