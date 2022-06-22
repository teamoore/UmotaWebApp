using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class ImageDataDto
    {
        public int Logref { get; set; }
        public string TableName { get; set; }

        public int? TableLogref { get; set; }
        public byte[] iData { get; set; }
        public string iType { get; set; }
        public string FileName { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
