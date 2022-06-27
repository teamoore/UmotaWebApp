using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Server.Services.Email;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ServiceResponses;
using UmotaWebApp.Shared.SharedConsts;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private ILogger<PdfController> logger { get; }
        private IPdfGenerator pdf { get; set; }
        private IEmailSender _emailSender { get; set; }
        private ITeklifService teklifService { get; set; }
        private ISisKullaniciService sisKullaniciService { get; set;}

        public PdfController(ILogger<PdfController> logger, IPdfGenerator pdf, IEmailSender emailSender, ITeklifService teklifService, ISisKullaniciService sisKullaniciService)
        {
            this.logger = logger;
            this.pdf = pdf;
            this._emailSender = emailSender;
            this.teklifService = teklifService;
            this.sisKullaniciService = sisKullaniciService;
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

                    var subject = string.Format("Fiyat Teklifi {0}, {1}", request.teklif.Teklifno, request.teklif.Cariadi);

                    var message = new Message(new string[] { request.teklif.Mail }, subject, subject, pdfData);
                    var kullaniciDto = await sisKullaniciService.GetSisKullanici(request.Kullanici);

                    if (kullaniciDto == null)
                        throw new Exception("Gönderen Kullanıcı bulunamadı");
                    if (kullaniciDto.MailAdres.IsValidEmail() == false)
                        throw new Exception("Gönderici mail adresi geçersizdir, lütfen email adresinizi güncelleyiniz");
                    if (string.IsNullOrEmpty(kullaniciDto.MailSifre))
                        throw new Exception("Gönderici mail şifresi boş olamaz, lütfen email şifrenizi güncelleyiniz");

                    message.From = kullaniciDto.MailAdres;
                    message.SmtpPassword = kullaniciDto.MailSifre;

                    _emailSender.SendEmail(message);
                }

                //Müşteriye mail gönderildikten sonra teklif durumunu : Müşteri Onayı Bekleniyor a çek
                request.teklif.NewDuruminfo = TeklifDurum.MusteriOnayiBekliyor;
                request.teklif.Upduser = request.Kullanici;
                request.teklif.TeklifDurumAciklama = "Teklif " + request.teklif.Mail + " adresine gönderildi.";
               
                await teklifService.UpdateTeklifDurum(new TeklifRequestDto()
                {
                    Teklif = request.teklif,
                    kullanicikodu = request.Kullanici,
                    FirmaId = request.FirmaId
                });

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

        [HttpPost("CreateServisBilgilendirmePdfDocumentSendMail")]
        public async Task<ServiceResponse<PdfGenerateResponseDto>> CreateServisPdfDocumentSendMail(PdfServisGeneratorRequestDto request)
        {
            try
            {
                if (request.Servis == null)
                    throw new Exception("Servis kaydı bulunamadı");

                /*Email kontrolü yap*/

                if (string.IsNullOrEmpty(request.Servis.Cariadi))
                    throw new Exception("Cari adı mevcut değil");

                var filename = "";
                var file = "";
                byte[] pdfData = null;

                using (MemoryStream pdfStream = pdf.CreateServisBilgilendirmePdf(request.Servis))
                {
                    var g = Guid.NewGuid();

                    file = "ServisBilgi-" + g.ToString() + ".pdf";

                    filename = @$"{Environment.CurrentDirectory}/Media/Files/" + file;

                    FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

                    pdfData = pdfStream.ToArray();

                    await fs.WriteAsync(pdfData, 0, pdfData.Length);
                    fs.Close();
                    fs.Dispose();

                    var subject = string.Format("Servis Bilgilendirme {0}", request.Servis.Cariadi);

                    //var message = new Message(new string[] { request.teklif.Mail }, subject, subject, pdfData);
                    //var kullaniciDto = await sisKullaniciService.GetSisKullanici(request.Kullanici);

                    //if (kullaniciDto == null)
                    //    throw new Exception("Gönderen Kullanıcı bulunamadı");
                    //if (kullaniciDto.MailAdres.IsValidEmail() == false)
                    //    throw new Exception("Gönderici mail adresi geçersizdir, lütfen email adresinizi güncelleyiniz");
                    //if (string.IsNullOrEmpty(kullaniciDto.MailSifre))
                    //    throw new Exception("Gönderici mail şifresi boş olamaz, lütfen email şifrenizi güncelleyiniz");

                    //message.From = kullaniciDto.MailAdres;
                    //message.SmtpPassword = kullaniciDto.MailSifre;

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
    }
}
