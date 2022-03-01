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
    public class FirmaDonemController : ControllerBase
    {
        public ILogger<FirmaDonemController> Logger { get; }

        public ISisFirmaDonemService SisFirmaDonemService { get; }

        public FirmaDonemController(ILogger<FirmaDonemController> logger, ISisFirmaDonemService sisFirmaDonemService)
        {
            Logger = logger;
            SisFirmaDonemService = sisFirmaDonemService;
        }

        [HttpGet("List")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<SisFirmaDonemDto>>> GetSisFirmaDonem(string kullanici_kodu)
        {
            try
            {
                return new ServiceResponse<List<SisFirmaDonemDto>>()
                {
                    Value = await SisFirmaDonemService.GetSisFirmaDonem(kullanici_kodu)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SisFirmaDonemDto>>();
                e.SetException(ex);
                return e;
            }

        }
    }
}
