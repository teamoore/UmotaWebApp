using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SatisFaturaAnalizRaporuDto
    {
        public DateTime? fattar { get; set; }
        public int fattaray { get; set; }
        public int fattaryil { get; set; }
        public string fatno { get; set; }
        public double? miktar { get; set; }
        public double? fiyat { get; set; }
        public double? kdvmat { get; set; }
        public double? kdvtut { get; set; }
        public double? maliyettut { get; set; }
        public double? indirimtut { get; set; }
        public double? kartut { get; set; }
        public double? indirimoran { get; set; }
        public string faturaturadi { get; set; }
        public string carikodu { get; set; }
        public string caritanim { get; set; }
        public string malzkodu { get; set; }
        public string malztanim { get; set; }
        public string satici { get; set; }
        public string cariozelkod2 { get; set; }
        public string cariozelkod3 { get; set; }
        public string cariozelkod3aciklama { get; set; }
        public string satiraciklama { get; set; }
        public string faturaaciklama1 { get; set; }
        public string faturaaciklama2 { get; set; }
        public string marka { get; set; }
        public double? eurkur { get; set; }
        public string siparisno { get; set; }
        public string malzemegrupkodu { get; set; }
        public string malzemegrupadi { get; set; }
        public string malzemeozelkod1 { get; set; }
        public string malzemeozelkod1adi { get; set; }
        public string malzemeozelkod2 { get; set; }
        public string malzemeozelkod2adi { get; set; }

        public string fiyatFormatted
        {
            get
            {
                return this.fiyat.HasValue ? String.Format("{0:N2}", this.fiyat.Value) : "";
            }
        }

        public string fiyateurFormatted
        {
            get
            {
                return this.eurkur.HasValue && this.eurkur.Value > 0 && this.fiyat.HasValue && this.fiyat.Value > 0 ? String.Format("{0:N2}", this.fiyat.Value / this.eurkur.Value) : "";
            }
        }

        public string karoranFormatted
        {
            get
            {
                double oran = 0;
                if (this.maliyettut.Value == 0)
                {
                    oran = 100;
                }
                else 
                { 
                    if (this.kdvmat.Value > 0)
                    {
                        oran = (this.kartut.Value / this.kdvmat.Value) * 100;
                    }
                }

                if (this.miktar.Value < 0)
                {
                    oran = oran * -1;
                }

                return String.Format("{0:N2}", oran);
            }
        }

        public string kdvmatFormatted
        {
            get
            {
                return this.kdvmat.HasValue ? String.Format("{0:N2}", this.kdvmat.Value) : "";
            }
        }

        public string kdvtutFormatted
        {
            get
            {
                return this.kdvtut.HasValue ? String.Format("{0:N2}", this.kdvtut.Value) : "";
            }
        }

        public string maliyettutFormatted
        {
            get
            {
                return this.maliyettut.HasValue ? String.Format("{0:N2}", this.maliyettut.Value) : "";
            }
        }

        public string indirimtutFormatted
        {
            get
            {
                return this.indirimtut.HasValue ? String.Format("{0:N2}", this.indirimtut.Value) : "";
            }
        }
        public string indirimoranFormatted
        {
            get
            {
                return this.indirimoran.HasValue ? String.Format("{0:N2}", this.indirimoran.Value) : "";
            }
        }

        public string kartutFormatted
        {
            get
            {
                return this.kartut.HasValue ? String.Format("{0:N2}", this.kartut.Value) : "";
            }
        }

        public string faturatarihiFormatted
        {
            get
            {
                return this.fattar.HasValue ? this.fattar.Value.ToString("dd.MM.yyyy") : "-";
            }
        }

    }
}
