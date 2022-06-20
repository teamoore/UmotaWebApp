using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class FileUploadDto
    {
        public int LogRef { get; set; }
        public string TableName { get; set; }
        public int TableLogRef { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public string ImageFilePath { get; set; }

        public string FileName { get; set; }
        public string Aciklama { get; set; }
        public string Insuser { get; set; }
        public DateTime? Insdate { get; set; }
        public string Upduser { get; set; }
        public DateTime? Upddate { get; set; }

        public bool IsSuccessed { get; set; }
    }
}
