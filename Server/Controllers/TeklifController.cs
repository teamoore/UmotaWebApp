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
    [Route("api/[controller]")]
    [ApiController]
    public class TeklifController : ControllerBase
    {
        public ILogger<TeklifController> Logger { get; }
        public ITeklifService TeklifService { get; set; }

        public TeklifController(ILogger<TeklifController> logger, ITeklifService teklifService)
        {
            Logger = logger;
            TeklifService = teklifService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<TeklifDto>>> GetTeklifList()
        {
            try
            {
                return new ServiceResponse<List<TeklifDto>>()
                {
                    Value = await TeklifService.GetTeklifDtos()
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<TeklifDto>> SaveTeklif(TeklifDto teklif)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.SaveTeklif(teklif)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
