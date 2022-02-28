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
    public class CariKartController : ControllerBase
    {
        public ILogger<CariKartController> Logger { get; }
        public ICariKartService CariKartService { get; }

        public CariKartController(ILogger<CariKartController> logger, ICariKartService cariKartService)
        {
            Logger = logger;
            CariKartService = cariKartService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<CariKartDto>>> CariKartListele(string firmaId)
        {
            try
            {
                return new ServiceResponse<List<CariKartDto>>()
                {
                    Value = await CariKartService.GetCariKartDtos(firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<CariKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("getByKod")]
        public async Task<ServiceResponse<CariKartDto>> CariKartGetir(string kod, string firmaId)
        {
            try
            {
                return new ServiceResponse<CariKartDto>()
                {
                    Value = await CariKartService.GetCariKartByKod(kod, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<CariKartDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<CariKartDto>> CariKartKaydet(CariKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<CariKartDto>
                {
                    Value = await CariKartService.SaveCariKart(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<CariKartDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<CariKartDto>> CariKartGuncelle(CariKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<CariKartDto>
                {
                    Value = await CariKartService.UpdateCariKart(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<CariKartDto>();
                e.SetException(ex);
                return e;
            }
        }


        [HttpPost("search")]
        public async Task<ServiceResponse<List<CariKartDto>>> CariKartAra(CariKartRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<CariKartDto>>()
                {
                    Value = await CariKartService.SearchCariKarts(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<CariKartDto>>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
