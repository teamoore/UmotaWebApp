using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class PdfGenerateResponseDto
    {
        public bool isSuccess { get; set; }
        public string PdfPath { get; set; }
        public byte[] PdfFile { get; set; }
    }
}
