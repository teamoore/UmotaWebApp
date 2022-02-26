using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SisFirmaDonemDto
    {
        public int logref { get; set; }
        public short? firma_no { get; set; }
        public short? yil { get; set; }
        public short? logo_firma { get; set; }
        public short? logo_donem { get; set; }
        public byte? ondeger { get; set; }
        public string aciklama { get; set; }
    }
}
