using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [HttpPost("save")]
        public async Task<ServiceResponse<bool>> DosyaKaydet(FileUploadRequestDto request)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await fileUpload.Save(request)
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
