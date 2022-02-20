using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeklifDetayController : ControllerBase
    {
        public ILogger<TeklifDetayController> Logger { get; }
        public ITeklifDetayService TeklifDetayService { get; }

        public TeklifDetayController(ILogger<TeklifDetayController> logger, ITeklifDetayService teklifDetayService)
        {
            Logger = logger;
            TeklifDetayService = teklifDetayService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<TeklifDetayDto>>> GetTeklifList(int teklifRef)
        {
            try
            {
                return new ServiceResponse<List<TeklifDetayDto>>()
                {
                    Value = await TeklifDetayService.GetTeklifDetays(teklifRef)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDetayDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<TeklifDetayDto>> GetTeklifDetay(int logref)
        {
            try
            {
                return new ServiceResponse<TeklifDetayDto>()
                {
                    Value = await TeklifDetayService.GetTeklifDetay(logref)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDetayDto>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
