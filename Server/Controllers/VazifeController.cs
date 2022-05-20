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
    [Route("api/[controller]")]
    [ApiController]
    public class VazifeController : ControllerBase
    {
        public ILogger<VazifeController> Logger { get; }
        public IVazifeService dataService { get; set; }

        public VazifeController(ILogger<VazifeController> logger, IVazifeService dataService)
        {
            Logger = logger;
            this.dataService = dataService;
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<VazifeDto>> VazifeKaydet(VazifeRequestDto request)
        {
            try
            {
                return new ServiceResponse<VazifeDto>()
                {
                    Value = await dataService.SaveVazife(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<VazifeDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("list")]
        public async Task<ServiceResponse<List<VazifeDto>>> VazifeGetir(VazifeRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<VazifeDto>>()
                {
                    Value = await dataService.GetVazifes(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<VazifeDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<VazifeDto>> VazifeGuncelle(VazifeRequestDto request)
        {
            try
            {
                return new ServiceResponse<VazifeDto>()
                {
                    Value = await dataService.UpdateVazife(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<VazifeDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<VazifeDto>> VazifeGetir(short firmaId, int logref)
        {
            try
            {
                return new ServiceResponse<VazifeDto>()
                {
                    Value = await dataService.GetVazife(firmaId, logref)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<VazifeDto>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
