using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TalepDosyaRequestDto
    {
        public Stream   FileStream { get; set; }
        public string FileName { get; set; }
        public int TalepLogRef { get; set; }
        public string InsUser { get; set; }
        public string FileType { get; set; }
    }
}
