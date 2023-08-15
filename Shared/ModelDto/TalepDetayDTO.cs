using System;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepDetayDTO
    {
        public int ParLogRef { get; set; }
        public int SiraNo { get; set; }

        public int mahal1ref { get; set; }
        public int mahal2ref { get; set; }
        public int mahal3ref { get; set; }
        public int mahal4ref { get; set; }
        public int mahal5ref { get; set; }

        public int Aktivite1Ref { get; set; }
        public int Aktivite2Ref { get; set; }
        public int Aktivite3Ref { get; set; }
        public int Aktivite4Ref { get; set; }
        public int Aktivite5Ref { get; set; }
        public int KaynakRef { get; set; }

        public int TeslimYeriRef { get; set; }
        public DateTime TeslimTarihi { get; set; }

        public double SipMiktar { get; set; }
        public double FisMiktar { get; set; }
        public double KalanMiktar { get; set; }
        public double PlFisMiktar { get; set; }
        public double PlSipMiktar { get; set; }

        public string Marka { get; set; }

        public string Aciklama { get; set; }

        public double Miktar { get; set; }

        public int BirimRef { get; set; }

        public int logref { get; set; }
        public byte status { get; set; }

        public string? insuser { get; set; }
        public DateTime? insdate { get; set; }
        public string? upduser { get; set; }
        public DateTime? upddate { get; set; }


    }
}
