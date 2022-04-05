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

        [HttpPost("search")]
        public async Task<ServiceResponse<List<MalzemeKartDto>>> GetMalzemeKartSearchList(MalzemeKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<MalzemeKartDto>>()
                {
                    Value = await MalzemeKartService.SearchMalzemeKart(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<MalzemeKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<MalzemeKartDto>> GetTeklifDetay(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<MalzemeKartDto>()
                {
                    Value = await MalzemeKartService.GetMalzemeKart(logref,firmaId)
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

        [HttpPost("fiyatgetir")]
        public async Task<ServiceResponse<MalzemeFiyatDto>> MalzemeFiyatiGetir(MalzemeFiyatRequestDto request)
        {
            try
            {
                return new ServiceResponse<MalzemeFiyatDto>()
                {
                    Value = await MalzemeKartService.MalzemeFiyatGetir(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<MalzemeFiyatDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("maliyetgetir")]
        public async Task<ServiceResponse<MalzemeFiyatDto>> MalzemeMaliyetiGetir(MalzemeFiyatRequestDto request)
        {
            try
            {
                return new ServiceResponse<MalzemeFiyatDto>()
                {
                    Value = await MalzemeKartService.MalzemeMaliyetGetir(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<MalzemeFiyatDto>();
                e.SetException(ex);
                return e;
            }

        }

        [HttpPost("stokgetir")]
        public async Task<ServiceResponse<List<MalzemeStokDto>>> GetMalzemeKartSearchListStoklu(MalzemeStokRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<MalzemeStokDto>>()
                {
                    Value = await MalzemeKartService.SearchMalzemeKartStoklu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<MalzemeStokDto>>();
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

        [HttpGet("GetBirimSetList")]
        public async Task<ServiceResponse<IEnumerable<MalzemeBirimSetDto>>> GetBirimSetList(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<MalzemeBirimSetDto>>()
                {
                    Value = await MalzemeKartService.GetMalzemeBirimSetList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<MalzemeBirimSetDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetGrupList")]
        public async Task<ServiceResponse<IEnumerable<SpeCodesDto>>> GetGrupList(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<SpeCodesDto>>()
                {
                    Value = await MalzemeKartService.GetMalzemeGrupList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<SpeCodesDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetMarkaList")]
        public async Task<ServiceResponse<IEnumerable<SpeCodesDto>>> GetMarkaist(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<SpeCodesDto>>()
                {
                    Value = await MalzemeKartService.GetMalzemeMarkaList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<SpeCodesDto>>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
