using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FirmaController : ControllerBase
    {
        public ILogger<FirmaController> Logger { get; }
        public ISisFirmaService SisFirmaService { get; }

        public FirmaController(ILogger<FirmaController> logger, ISisFirmaService sisFirmaService)
        {
            Logger = logger;
            SisFirmaService = sisFirmaService;
        }


        [HttpGet("List")]
        public async Task<ServiceResponse<List<SisFirmaFirmaDonemDto>>> GetSisFirmaFirmaDonem()
        {
            try
            {
                return new ServiceResponse<List<SisFirmaFirmaDonemDto>>()
                {
                    Value = await SisFirmaService.GetFirmaDonems()
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SisFirmaFirmaDonemDto>>();
                e.SetException(ex);
                return e;
            }

        }

    }
}
