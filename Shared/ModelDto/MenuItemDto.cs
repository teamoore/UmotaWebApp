using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MenuItemDto
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public short? Modul { get; set; }
        public string Secenek { get; set; }
        public string Tanimi { get; set; }
        public string HRef { get; set; }
        public short? SiraNo { get; set; }
        public bool GirisEkrani { get; set; }
        public string imageName { get; set; }
        
    }
}
