using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Server.Services.Email;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.Config;
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
        private IEmailSender _emailSender { get; set; }

        public PdfController(ILogger<PdfController> logger, IPdfGenerator pdf, IEmailSender emailSender)
        {
            this.logger = logger;
            this.pdf = pdf;
            this._emailSender = emailSender;
        }

        [HttpPost("CreateTeklifPdfDocument")]
        public async Task<ServiceResponse<PdfGenerateResponseDto>> CreateTeklifPdfDocument(PdfGeneratorRequestDto request)
        {
            try
            {
                var filename = "";
                var file = "";
                byte[] pdfData = null;

                using (MemoryStream pdfStream = pdf.CreateTeklifDetayPdf(request.teklif, request.teklifDetays, request.PdfType))
                {
                    var g = Guid.NewGuid();
                    
                    file = "Teklif-" + g.ToString() + ".pdf";

                    filename = @$"{Environment.CurrentDirectory}/Media/Files/" + file;

                    FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

                    pdfData = pdfStream.ToArray();

                    await fs.WriteAsync(pdfData, 0, pdfData.Length);
                    fs.Close();

                    //var message = new Message(new string[] { request.teklif.Mail }, "Uno Teklif", "Teklif ektedir.", pdfData);
                    //_emailSender.SendEmail(message);
                }

                return new ServiceResponse<PdfGenerateResponseDto>()
                {
                    Value = new PdfGenerateResponseDto()
                    {
                        isSuccess = true,
                        PdfPath = file,
                        PdfFile = pdfData
                    }
                };
            }
            catch (Exception ex)
            {
                var e = new ServiceResponse<PdfGenerateResponseDto>();
                e.SetException(ex);
                return e;
            }

          
        }


        [HttpPost("CreateTeklifPdfDocumentSendMail")]
        public async Task<ServiceResponse<PdfGenerateResponseDto>> CreateTeklifPdfDocumentSendMail(PdfGeneratorRequestDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.teklif.Mail))
                {
                    throw new Exception("Yetkili e-posta adresi boş olamaz");
                }

                if (request.teklif.Mail.IsValidEmail() == false)
                {
                    throw new Exception("Geçersiz e-posta adresi : " + request.teklif.Mail);
                }

                var filename = "";
                var file = "";
                byte[] pdfData = null;

                using (MemoryStream pdfStream = pdf.CreateTeklifDetayPdf(request.teklif, request.teklifDetays, request.PdfType))
                {
                    var g = Guid.NewGuid();

                    file = "Teklif-" + g.ToString() + ".pdf";

                    filename = @$"{Environment.CurrentDirectory}/Media/Files/" + file;

                    FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

                    pdfData = pdfStream.ToArray();

                    await fs.WriteAsync(pdfData, 0, pdfData.Length);
                    fs.Close();

                    var message = new Message(new string[] { request.teklif.Mail }, "Uno Teklif", "Teklif ektedir.", pdfData);
                    _emailSender.SendEmail(message);
                }

                return new ServiceResponse<PdfGenerateResponseDto>()
                {
                    Value = new PdfGenerateResponseDto()
                    {
                        isSuccess = true,
                        PdfPath = file,
                        PdfFile = pdfData
                    }
                };
            }
            catch (Exception ex)
            {
                var e = new ServiceResponse<PdfGenerateResponseDto>();
                e.SetException(ex);
                return e;
            }


        }
    }
}
