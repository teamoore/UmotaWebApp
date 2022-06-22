using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class FileDataDto
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }

        public string FileName { get; set; }
    }
}
