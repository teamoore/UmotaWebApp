using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TeklifDetayDto
    {
        public int Logref { get; set; }
        public int? Teklifref { get; set; }
        public string Cizimkodu { get; set; }
        public string Sipnosira { get; set; }
        public int? LstokId { get; set; }
        public string LstokKodu { get; set; }
        public string LstokAdi { get; set; }
        public int? Unitsetref { get; set; }
        public int? Unitsetllogref { get; set; }
        public string Aciklama { get; set; }
        public int? Dovizref { get; set; }
        public double? Dovizkuru { get; set; }
        public double? Miktar { get; set; }
        public double? Fiyat { get; set; }
        public double? Fiyattl { get; set; }
        public double? Tutar { get; set; }
        public double? Tutartl { get; set; }
        public double? Tutarrd { get; set; }
        public double? Tutarid { get; set; }
        public double? Iskyuz1 { get; set; }
        public double? Isktut1 { get; set; }
        public double? Isktut1tl { get; set; }
        public double? Isktut1rd { get; set; }
        public double? Isktut1id { get; set; }
        public double? Iskyuz2 { get; set; }
        public double? Isktut2 { get; set; }
        public double? Isktut2tl { get; set; }
        public double? Isktut2rd { get; set; }
        public double? Isktut2id { get; set; }
        public double? Iskyuz3 { get; set; }
        public double? Isktut3 { get; set; }
        public double? Isktut3tl { get; set; }
        public double? Isktut3rd { get; set; }
        public double? Isktut3id { get; set; }
        public double? Iskyuz4 { get; set; }
        public double? Isktut4 { get; set; }
        public double? Isktut4tl { get; set; }
        public double? Isktut4rd { get; set; }
        public double? Isktut4id { get; set; }
        public double? Kdvmatrah { get; set; }
        public double? Kdvmatrahtl { get; set; }
        public double? Kdvmatrahrd { get; set; }
        public double? Kdvmatrahid { get; set; }
        public byte? Kdvkod { get; set; }
        public double? Kdvyuz { get; set; }
        public double? Kdvtut { get; set; }
        public double? Kdvtuttl { get; set; }
        public double? Kdvtutrd { get; set; }
        public double? Kdvtutid { get; set; }
        public double? Nettutar { get; set; }
        public double? Nettutartl { get; set; }
        public double? Nettutarrd { get; set; }
        public double? Nettutarid { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public string Duruminfo { get; set; }
        public string Ebat { get; set; }
        public string Marka { get; set; }
        public string Mensei { get; set; }
        public string Lfirma { get; set; }
        public string Ldonem { get; set; }
        public double? Maliyet1 { get; set; }
        public double? Maliyet2 { get; set; }
        public double? Maliyet1id { get; set; }
        public double? Maliyet2id { get; set; }
        public int? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public int? Siplogref { get; set; }
        public int? FiltreHarRef { get; set; }
        public string Malzkodu { get; set; }
        public string Malzadi { get; set; }
        public string Ozelkod5 { get; set; }
        public string Birimkodu { get; set; }
        public string Dovizdoku { get; set; }
        public string Satsipno { get; set; }
        public int? Satmalzlogref { get; set; }
        public string MontajYeri { get; set; }
        public string Mahal { get; set; }

        private double? _netFiyatid = 0;
        public double? NetFiyatid
        {
            get
            {
                if (this.Miktar.HasValue == false)
                    return 0;

                if (this.Kdvmatrahid.HasValue)
                    return this.Kdvmatrahid.Value / this.Miktar.Value;

                return 0;
            }
            set
            {
                _netFiyatid = value;
            }
        }

        private double? _fiyatid = 0;
        public double? Fiyatid
        {
            get
            {
                if (this.Miktar.HasValue == false)
                    return 0;

                if (this.Tutarid.HasValue)
                    return this.Tutarid.Value / this.Miktar.Value;

                return 0;
            }
            set
            {
                _fiyatid = value;
            }
        }
    }
}
