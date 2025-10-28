using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public ILogger<FileUploadController> Logger { get; }
        public IFileUpload fileUpload { get; set; }
        public FileUploadController(ILogger<FileUploadController> logger, IFileUpload fileUpload)
        {
            Logger = logger;
            this.fileUpload = fileUpload;
        }

        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<ServiceResponse<FileUploadDto>> DosyaYukle(IBrowserFile file)
        {
            try
            {
                return new ServiceResponse<FileUploadDto>()
                {
                    Value = await fileUpload.Upload(file,CancellationToken.None)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<FileUploadDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("upload2")]
        [DisableRequestSizeLimit]
        public async Task<ServiceResponse<FileUploadDto>> DosyaYukle2(FileDataDto file)
        {
            try
            {
                return new ServiceResponse<FileUploadDto>()
                {
                    Value = await fileUpload.Upload(file)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<FileUploadDto>();
                e.SetException(ex);
                return e;
            }
        }

        [RequestSizeLimit(long.MaxValue)]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [HttpPost("single")]
        public async Task<IActionResult> Single(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yüklenmedi.");

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            // Sadece .xls ve .xlsx uzantılarına izin ver
            if (extension != ".xls" && extension != ".xlsx")
                return BadRequest("Sadece Excel (.xls, .xlsx) dosyalarına izin verilmektedir.");
            
            try
            {
                var filePath = Path.Combine("wwwroot/dosyalar", file.FileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                return Ok(new { message = "Yükleme tamamlandı!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<ImageDataDto>> DosyaKaydet(FileUploadRequestDto request)
        {
            try
            {
                return new ServiceResponse<ImageDataDto>()
                {
                    Value = await fileUpload.Save(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ImageDataDto>();
                e.SetException(ex);
                return e;
            }
        }


        [HttpPost("list")]
        public async Task<ServiceResponse<List<ImageDataDto>>> DosyalariGetir(FileUploadRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<ImageDataDto>>()
                {
                    Value = await fileUpload.GetList(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<ImageDataDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("delete")]
        public async Task<ServiceResponse<bool>> DosyaSil(FileUploadRequestDto request)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await fileUpload.DeleteFile(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<bool>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
