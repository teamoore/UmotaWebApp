﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace Prizma.Core.Model
{
    public class TalepDetay : BaseEntity
    {
        private TalepDetay()
        {
                
        }

        #region Alanlar
        public string? Aciklama { get; private set; }
        public double Miktar { get; private set; }
        public int BirimRef { get; private set; }
        public int mahal1ref { get; private set; }
        public int mahal2ref { get; private set; }
        public int mahal3ref { get; private set; }
        public int mahal4ref { get; private set; }
        public int mahal5ref { get; private set; }

        public int? Aktivite1Ref { get; private set; }
        public int? Aktivite2Ref { get; private set; }
        public int? Aktivite3Ref { get; private set; }
        public int? Aktivite4Ref { get; private set; }
        public int? Aktivite5Ref { get; private set; }

        public int? TeslimYeriRef { get; private set; }
        public DateTime? TeslimTarihi { get; private set; }

        public double? SipMiktar { get; private set; }
        public double? FisMiktar { get; private set; }
        public double? KalanMiktar { get; private set; }
        public double? PlFisMiktar { get; private set; }
        public double? PlSipMiktar { get; private set; }

        public int? ParLogRef { get; private set; }

        public double? SiraNo { get; private set; }

        public string? Marka { get; set; }

        #endregion

        public static TalepDetay Create(string aciklama,double miktar, int birimRef) 
        {
            return new TalepDetay
            {
                Aciklama = aciklama,
                Miktar = miktar,
                BirimRef = birimRef
            };
        }

        public void ChangeMiktar(double miktar)
        {
            this.Miktar = miktar;
        }

    }
}
