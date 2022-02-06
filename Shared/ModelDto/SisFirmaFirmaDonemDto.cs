using System;
namespace UmotaWebApp.Shared.ModelDto
{
    public class SisFirmaFirmaDonemDto
    {

        public string FirmaNo { get; set; }
        public string FirmaAdi { get; set; }
        public bool? LogoStokKart { get; set; }
        public bool? LogoCariKart { get; set; }
        public bool? LogoHizmetKart { get; set; }
        public string LogoFirmaNo { get; set; }

        public int Logref { get; set; }
     
        public short? Yil { get; set; }
        public short? LogoFirma { get; set; }
        public short? LogoDonem { get; set; }
        public byte? Ondeger { get; set; }
        public string Aciklama { get; set; }
    }
}
