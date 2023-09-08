using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Core.Model
{
    public class SiparisDetay : BaseEntity
    {

        #region Alanlar
        public int? ParLogRef { get; private set; }
        public double? SiraNo { get; private set; }
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
        public int? KaynakRef { get; private set; }
        public string? Aciklama { get; private set; }
        public double Miktar { get; private set; }
        public int BirimRef { get; private set; }
        public int? TeslimYeriRef { get; private set; }
        public DateTime? TeslimTarihi { get; private set; }
        public int? TalepRef { get; private set; }
        public int? TalepDetayRef { get; private set; }
        public double? Fiyat { get; private set; }
        public int? FDovizRef { get; private set; }
        public double? FDovizKuru { get; private set; }
        public double? Tutar { get; private set; }
        public double? TutarTL { get; private set; }
        public double? TutarRD { get; private set; }
        public double? TutarID { get; private set; }
        public double? IskYuz { get; private set; }
        public double? IskTut { get; private set; }
        public double? IskTutTL { get; private set; }
        public double? IskTutRD { get; private set; }
        public double? IskTutID { get; private set; }
        public byte KdvKod { get; set; }
        public double? KdvYuz { get; private set; }
        public double? KdvTut { get; private set; }
        public double? KdvTutTL { get; private set; }
        public double? KdvTutRD { get; private set; }
        public double? KdvTutID { get; private set; }
        public double? TutarNet { get; private set; }
        public double? TutarNetTL { get; private set; }
        public double? TutarNetRD { get; private set; }
        public double? TutarNetID { get; private set; }
        public double SevkMiktar { get; private set; }
        public double KalanMiktar { get; private set; }
        public double TalepBirimMiktar { get; private set; }
        public byte TalepMiktarFarki { get; set; }
        #endregion

        public SiparisDetay() { }
    }
}
