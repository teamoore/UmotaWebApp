using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class MalzemeKartController : ControllerBase
    {
        public ILogger<MalzemeKartController> Logger { get; }
        public IMalzemeKartService MalzemeKartService { get; }

        public MalzemeKartController(ILogger<MalzemeKartController> logger, IMalzemeKartService malzemeKartService)
        {
            Logger = logger;
            MalzemeKartService = malzemeKartService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<UrunDto>>> MalzemeKartListele(string firmaId)
        {
            try
            {
                return new ServiceResponse<List<UrunDto>>()
                {
                    Value = await MalzemeKartService.GetMalzemeKarts(firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<UrunDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<UrunDto>>> GetMalzemeKartSearchList(MalzemeKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<UrunDto>>()
                {
                    Value = await MalzemeKartService.SearchMalzemeKarts(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<UrunDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<UrunDto>> GetMalzemeKart(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<UrunDto>()
                {
                    Value = await MalzemeKartService.GetMalzemeKart(logref,firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<UrunDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<MalzemeKartDto>> InsertMalzemeKart(MalzemeKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<MalzemeKartDto>()
                {
                    Value = await MalzemeKartService.SaveMalzemeKart(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<MalzemeKartDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<MalzemeKartDto>> UpdateMalzemeKart(MalzemeKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<MalzemeKartDto>()
                {
                    Value = await MalzemeKartService.UpdateMalzemeKart(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<MalzemeKartDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetFotoList")]
        public async Task<ServiceResponse<List<string>>> GetFotoList(int urunID)
        {
            try
            {
                return new ServiceResponse<List<string>>()
                {
                    Value = await MalzemeKartService.GetFotoList(urunID)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<string>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetUserSepetList")]
        public async Task<ServiceResponse<List<SepetDto>>> GetUserSepetList(string kullaniciKodu)
        {
            try
            {
                return new ServiceResponse<List<SepetDto>>()
                {
                    Value = await MalzemeKartService.GetUserSepetList(kullaniciKodu)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SepetDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetSepetUrunList")]
        public async Task<ServiceResponse<List<SepetUrunDto>>> GetSepetUrunList(string kullaniciKodu, string sepetAdi)
        {
            try
                {
                return new ServiceResponse<List<SepetUrunDto>>()
                {
                    Value = await MalzemeKartService.GetSepetUrunList(kullaniciKodu, sepetAdi)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SepetUrunDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("DeleteUserSepet")]
        public async Task<ServiceResponse<int>> DeleteUserSepet(string kullaniciKodu, string sepetAdi)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await MalzemeKartService.DeleteUserSepet(kullaniciKodu, sepetAdi)
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

        [HttpGet("DeleteSepetUrun")]
        public async Task<ServiceResponse<int>> DeleteSepetUrun(int urunId)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await MalzemeKartService.DeleteSepetUrun(urunId)
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

        [HttpPost("postsepet")]
        public async Task<ServiceResponse<int>> PostSepet(SepetPostDto request)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await MalzemeKartService.SepetPost(request)
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

        [HttpGet("getusersepetcount")]
        public async Task<ServiceResponse<int>> GetUserSepetCount(string kullaniciKodu)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await MalzemeKartService.GetUserSepetCount(kullaniciKodu)
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

        [HttpGet("UrunExcelAktar")]
        public async Task<ServiceResponse<int>> UrunExcelAktar(string excelFileName, string kullaniciKodu)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await MalzemeKartService.ExceldenUrunleriAktar(excelFileName, kullaniciKodu)
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
    }
}
