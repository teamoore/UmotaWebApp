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
    public class VMalzemeKartController : ControllerBase
    {
        public ILogger<VMalzemeKartController> Logger { get; }
        public IVMalzemeKartService MalzemeKartService { get; }

        public VMalzemeKartController(ILogger<VMalzemeKartController> logger, IVMalzemeKartService malzemeKartService)
        {
            Logger = logger;
            MalzemeKartService = malzemeKartService;
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<VMalzemeKartDto>>> SearchVMalzemeKartss(VMalzemeKartsRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<VMalzemeKartDto>>()
                {
                    Value = await MalzemeKartService.SearchVMalzemeKarts(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<VMalzemeKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<VMalzemeKartDto>> GetVMalzemeKartt(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<VMalzemeKartDto>()
                {
                    Value = await MalzemeKartService.GetVMalzemeKart(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<VMalzemeKartDto>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
