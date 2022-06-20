using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class FileUploadRequestDto
    {
        public IFormFile UploadedFile { get; set; }
        public FileUploadDto File { get; set; }
        public short FirmaId { get; set; }
    }
}
