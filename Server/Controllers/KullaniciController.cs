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
    [Authorize]
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

        [HttpGet("GetByKod")]
        public async Task<ServiceResponse<SisKullaniciDto>> GetSisKullaniciGetByKod(string kod)
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

        [HttpGet("GetKullaniciYetkisi")]
        public async Task<ServiceResponse<int>> GetKullaniciYetkisi(string kullanicikodu, string yetkikodu)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, yetkikodu)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<int>();
                e.SetException(ex);
                return e;
            }

        }

        [HttpGet("GetKullaniciMenuYetkisi")]
        public async Task<ServiceResponse<int>> GetKullaniciMenuYetkisi(string kullanicikodu, string menu_dfm, string hak_tipi)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await SisKullaniciService.GetKullaniciMenuYetkisiByMenuAdi(kullanicikodu, menu_dfm, hak_tipi)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<int>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("gruplist")]
        public async Task<ServiceResponse<List<SisMenuProfilDto>>> GetSisKullaniciGrupList()
        {
            try
            {
                return new ServiceResponse<List<SisMenuProfilDto>>()
                {
                    Value = await SisKullaniciService.GetKullaniciGrupList()
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SisMenuProfilDto>>();
                e.SetException(ex);
                return e;
            }

        }

        [HttpPost("save")]
        public async Task<ServiceResponse<SisKullaniciDto>> KullaniciSave(SisKullaniciRequestDto request)
        {
            try
            {
                return new ServiceResponse<SisKullaniciDto>()
                {
                    Value = await SisKullaniciService.SaveKullanici(request)
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

        [HttpPost("update")]
        public async Task<ServiceResponse<SisKullaniciDto>> KullaniciUpdate(SisKullaniciRequestDto request)
        {
            try
            {
                return new ServiceResponse<SisKullaniciDto>()
                {
                    Value = await SisKullaniciService.UpdateKullanici(request)
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

    }
}
