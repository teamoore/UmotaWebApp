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
        public async Task<ServiceResponse<List<MalzemeKartDto>>> GetMalzemeKartList()
        {
            try
            {
                return new ServiceResponse<List<MalzemeKartDto>>()
                {
                    Value = await MalzemeKartService.GetMalzemeKartList()
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<MalzemeKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<MalzemeKartDto>> GetTeklifDetay(int logref)
        {
            try
            {
                return new ServiceResponse<MalzemeKartDto>()
                {
                    Value = await MalzemeKartService.GetMalzemeKart(logref)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<MalzemeKartDto>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
