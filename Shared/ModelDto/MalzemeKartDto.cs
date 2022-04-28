using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MalzemeKartDto
    {
        public int Logref { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Adi3 { get; set; }
        public string Birim { get; set; }
        public string Birimset { get; set; }
        public string Mensei { get; set; }
        public string Grupkodu { get; set; }
        public string Marka { get; set; }
        public string Ozelkod { get; set; }
        public string Ozelkod2 { get; set; }
        public string Ozelkod3 { get; set; }
        public string Ozelkod4 { get; set; }
        public double? En { get; set; }
        public double? Boy { get; set; }
        public double? Yukseklik { get; set; }
        public double? Hacim { get; set; }
        public byte? Kdv { get; set; }
        public double? Alfiyat { get; set; }
        public string AlfiyatDov { get; set; }
        public double? Satfiyat { get; set; }
        public string SatfiyatDov { get; set; }
        public int? Unitsetllogref { get; set; }
        public int? Unitsetref { get; set; }
        public int? Logoref { get; set; }
        public string Logokodu { get; set; }
        public byte? Active { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        private double? _kdvNumber;
        public double? KdvNumber
        { 
            get 
            {
                return (double?)this.Kdv;
            }
            set {
                _kdvNumber = value;
                this.Kdv = (byte?)_kdvNumber;
            }
        }
        public string TedarikciAdi { get; set; }

        public SpeCodesDto SpecCodes { get; set; }
    }
}
