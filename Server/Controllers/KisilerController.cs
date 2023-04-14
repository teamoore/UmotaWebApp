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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KisilerController : ControllerBase
    {
        public ILogger<KisilerController> Logger { get; }
        public IKisilerService KisilerService { get; }

        public KisilerController(ILogger<KisilerController> logger, IKisilerService cariKartService)
        {
            Logger = logger;
            KisilerService = cariKartService;
        }

        [HttpGet("getcarikisiler")]
        public async Task<ServiceResponse<List<KisilerDto>>> GetCariKartKisilerr(int cariref, string firmaId)
        {
            try
            {
                return new ServiceResponse<List<KisilerDto>>()
                {
                    Value = await KisilerService.GetCariKartKisiler(cariref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<KisilerDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<KisilerDto>> KisiGetir(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<KisilerDto>()
                {
                    Value = await KisilerService.GetKisi(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<KisilerDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<KisilerDto>>> GetKisilerr(string firmaId)
        {
            try
            {
                return new ServiceResponse<List<KisilerDto>>()
                {
                    Value = await KisilerService.GetKisiler(firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<KisilerDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<KisilerDto>>> CariKartAra(KisilerRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<KisilerDto>>()
                {
                    Value = await KisilerService.SearchKisiler(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<KisilerDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<KisilerDto>> KisiKaydet(KisilerRequestDto request)
        {
            try
            {
                return new ServiceResponse<KisilerDto>
                {
                    Value = await KisilerService.SaveCariKartKisi(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<KisilerDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<KisilerDto>> KisiGuncelle(KisilerRequestDto request)
        {
            try
            {
                return new ServiceResponse<KisilerDto>
                {
                    Value = await KisilerService.UpdateKisi(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<KisilerDto>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
