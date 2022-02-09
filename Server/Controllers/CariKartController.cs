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
        public async Task<ServiceResponse<List<CariKartDto>>> CariKartListele()
        {
            try
            {
                return new ServiceResponse<List<CariKartDto>>()
                {
                    Value = await CariKartService.GetCariKartDtos()
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
