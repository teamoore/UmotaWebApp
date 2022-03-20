using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private ILogger<PdfController> logger { get; }
        private IPdfGenerator pdf { get; set; }

        public PdfController(ILogger<PdfController> logger, IPdfGenerator pdf)
        {
            this.logger = logger;
            this.pdf = pdf;
        }

        [HttpPost("CreateTeklifPdfDocument")]
        public async Task<ServiceResponse<bool>> CreateTeklifPdfDocument(PdfGeneratorRequestDto request)
        {
            try
            {
                using (MemoryStream pdfStream = pdf.CreateTeklifDetayPdf(request.teklif, request.teklifDetays))
                {
                    var g = Guid.NewGuid();
                    
                    var filename = @$"{Environment.CurrentDirectory}/Media/Files/Teklif-"+ g.ToString() +".pdf";

                    FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

                    byte[] pdfData = pdfStream.ToArray();

                    await fs.WriteAsync(pdfData, 0, pdfData.Length);
                    fs.Close();
                }

                return new ServiceResponse<bool>()
                {
                    Value = true
                };
            }
            catch (Exception ex)
            {
                var e = new ServiceResponse<bool>();
                e.SetException(ex);
                return e;
            }

          
        }

    }
}
