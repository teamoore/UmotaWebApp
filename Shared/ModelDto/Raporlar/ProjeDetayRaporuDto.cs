using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class ProjeDetayRaporuDto
    {
        public int ID { get; set; }
        public int Firma { get; set; }
        public DateTime Tarih { get; set; }
        public int Yil { get; set; }
        public int Ay { get; set; }
        public string MalzemeHizmet { get; set; }
        public string MalzemeHizmetKodu { get; set; }
        public string MalzemeHizmetAdi { get; set; }
        public double Miktar { get; set; }
        public double Fiyat { get; set; }
        public double KdvliFiyat { get; set; }
        public double Tutar { get; set; }
        public double KdvTutar { get; set; }
        public double KdvliTutar { get; set; }
        public string Doviz { get; set; }
        public double Kur { get; set; }
        public double TutarTL { get; set; }
        public double TutarUSD { get; set; }
        public string FaturaNo { get; set; }
        public string FaturaOzelKod { get; set; }
        public string FaturaTuru { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string SatirAciklamasi { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeOzelKod { get; set; }
        public double SiparisMiktar { get; set; }


    }
}
