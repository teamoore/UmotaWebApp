using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class UrunDto
    {
        public int ID { get; set; }
        public string GrupKodu { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public string Baslik { get; set; }
        public string Ozellik { get; set; }
        public double Fiyat1 { get; set; }
        public double Fiyat2 { get; set; }
        public double Fiyat3 { get; set; }
        public int HesaplananAdet { get; set; }
        public string Sezon { get; set; }
        public string AktarimGrup { get; set; }
        public string imagePath { get; set; }
        public byte Aktif { get; set; }
        public byte Status { get; set; }
        public bool isDelete { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdUser { get; set; }
        public DateTime UpdDate { get; set; }
        public string DelUser { get; set; }
        public DateTime DelDate { get; set; }

        public List<string> Fotolar { get; set; } = new();
        public UrunDto()
        {

        }

    }
}
