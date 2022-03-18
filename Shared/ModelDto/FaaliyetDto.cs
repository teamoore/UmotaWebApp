using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class FaaliyetDto
    {
        public int Logref { get; set; }
        public string Giren { get; set; }
        public DateTime? Tarih { get; set; }
        public string Konu { get; set; }
        public int? IslemSayisi { get; set; }
        public string Yapilanlar { get; set; }
        public int? Cariref { get; set; }
        public int? Malzemeref { get; set; }
        public int? Kisiref { get; set; }
        public int? Kisiref2 { get; set; }
        public int? Kisiref3 { get; set; }
        public int? Kisiref4 { get; set; }
        public int? Kisiref5 { get; set; }
        public string Grup1 { get; set; }
        public string Grup2 { get; set; }
        public string Grup3 { get; set; }
        public string Grup4 { get; set; }
        public string Grup5 { get; set; }
        public byte? Status { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
        public byte? Islemturu { get; set; }
        public string Malzemekodu { get; set; }
        public string Malzemeadi { get; set; }
        public string Kisiadi { get; set; }
        public string Kisiceptel { get; set; }
        public string Kisiistel { get; set; }
        public string Kisievtel { get; set; }
        public string Kisimail { get; set; }
        public string Kisiadi2 { get; set; }
        public string Kisiceptel2 { get; set; }
        public string Kisiistel2 { get; set; }
        public string Kisievtel2 { get; set; }
        public string Kisimail2 { get; set; }
        public string Kisiadi3 { get; set; }
        public string Kisiceptel3 { get; set; }
        public string Kisiistel3 { get; set; }
        public string Kisievtel3 { get; set; }
        public string Kisimail3 { get; set; }
        public string Kisiadi4 { get; set; }
        public string Kisiceptel4 { get; set; }
        public string Kisiistel4 { get; set; }
        public string Kisievtel4 { get; set; }
        public string Kisimail4 { get; set; }
        public string Kisiadi5 { get; set; }
        public string Kisiceptel5 { get; set; }
        public string Kisiistel5 { get; set; }
        public string Kisievtel5 { get; set; }
        public string Kisimail5 { get; set; }
        public string Carikodu { get; set; }
        public string Cariadi { get; set; }
        public string Carimail { get; set; }
        public string Adi2 { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        public string Ulke { get; set; }

        public string TarihFormatted
        {
            get
            {
                return this.Tarih.HasValue ? this.Tarih.Value.ToString("dd.MM.yyyy") : "-";
            }
        }
    }
}
