using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        public ILogger<KullaniciController> Logger { get; }
        public ISisKullaniciService SisKullaniciService { get; }

        public KullaniciController(ILogger<KullaniciController> logger, ISisKullaniciService sisKullaniciService)
        {
            Logger = logger;
            SisKullaniciService = sisKullaniciService;
        }

        [HttpGet("List")]
        public async Task<ServiceResponse<List<SisKullaniciDto>>> GetSisKullaniciList()
        {
            try
            {
                return new ServiceResponse<List<SisKullaniciDto>>()
                {
                    Value = await SisKullaniciService.GetSisKullaniciList()
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SisKullaniciDto>>();
                e.SetException(ex);
                return e;
            }
 
        }

        [HttpPost("GetByKod")]
        public async Task<ServiceResponse<SisKullaniciDto>> GetSisKullanici(string kod)
        {
            try
            {
                return new ServiceResponse<SisKullaniciDto>()
                {
                    Value = await SisKullaniciService.GetSisKullanici(kod)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<SisKullaniciDto>();
                e.SetException(ex);
                return e;
            }
            
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<SisKullaniciLoginResponseDto>> Login(SisKullaniciLoginRequestDto request)
        {
            var result = new ServiceResponse<SisKullaniciLoginResponseDto>();
            try
            {
                Logger.LogInformation("Kullanıcı " + request.Kod + " login isteği gönderdi");

                result.Value = await SisKullaniciService.Login(new SisKullaniciLoginRequestDto() { Kod = request.Kod, Sifre = request.Sifre });
                
                Logger.Log(LogLevel.Information, "Kullanıcı login oldu : " + request.Kod);

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                Logger.Log(LogLevel.Error, ex.Message);
            }
            
            return result;
        }

    }
}
