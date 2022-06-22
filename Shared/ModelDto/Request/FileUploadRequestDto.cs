using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class FileUploadRequestDto
    {
        public ImageDataDto ImageData { get; set; }
        public FileUploadDto File { get; set; }
        public short FirmaId { get; set; }
        public string TableName { get; set; }
        public int? TableLogref { get; set; }
    }
}
