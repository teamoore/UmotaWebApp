using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeStokDto
    {
        public int MalzemeRef { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string MalzemeMarka { get; set; }
        public int BirimSetiRef { get; set; }
        public int BirimRef { get; set; }
        public string BirimKodu { get; set; }
        public string MalzemeOzelKod1 { get; set; }
        public string MalzemeOzelKod2 { get; set; }
        public string MalzemeOzelKod3 { get; set; }
        public string MalzemeOzelKod4 { get; set; }
        public string MalzemeOzelKod5 { get; set; }
        public string MalzemeOzelKod1Aciklama { get; set; }
        public string MalzemeOzelKod2Aciklama { get; set; }
        public string MalzemeOzelKod3Aciklama { get; set; }
        public string MalzemeOzelKod4Aciklama { get; set; }
        public string MalzemeOzelKod5Aciklama { get; set; }
        public double? MalzemeEbatYukseklik { get; set; }
        public double? MalzemeEbatEn { get; set; }
        public double? MalzemeEbatBoy { get; set; }
        public string MalzemeGrupAdi { get; set; }
        public double? StokMiktari { get; set; }
        public double? RezervMiktari { get; set; }
        public double? StokMiktari2 { get; set; }
        public double? BekleyenAlimSiparisMiktar { get; set; }
        public DateTime? BekleyenAlimSiparisTeslimTarihi { get; set; }
        public double? BekleyenOneriSatisSiparisMiktar { get; set; }
        public double? SatisFiyati { get; set; }
        public string SatisFiyatiDoviz { get; set; }
        public double? AlisFiyati { get; set; }
        public string AlisFiyatiDoviz { get; set; }
        public string MalzemeBarkod { get; set; }
        public string BekleyenAlimSiparisTeslimTarihiFormatted
        {
            get
            {
                return this.BekleyenAlimSiparisTeslimTarihi.HasValue ? this.BekleyenAlimSiparisTeslimTarihi.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
        public double? AlisFiyati2 { get; set; }
        public string SatisFiyatiFormatted
        {
            get
            {
                return this.SatisFiyati.HasValue ? String.Format("{0:N2}", this.SatisFiyati.Value) : "";
            }
        }
        public string AlisFiyatiFormatted
        {
            get
            {
                return this.AlisFiyati.HasValue ? String.Format("{0:N2}", this.AlisFiyati.Value) : "";
            }
        }
        public string AlisFiyati2Formatted
        {
            get
            {
                return this.AlisFiyati2.HasValue ? String.Format("{0:N2}", this.AlisFiyati2.Value) : "";
            }
        }
    }
}
