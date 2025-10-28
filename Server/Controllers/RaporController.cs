using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Client.Components.Raporlar;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ServiceResponses;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        public ILogger<RaporController> Logger { get; }
        public IRaporService RaporService { get; }

        public RaporController(ILogger<RaporController> logger, IRaporService raporService)
        {
            Logger = logger;
            RaporService = raporService;
        }

        [HttpPost("ProjeDetayRaporu")]
        public async Task<ServiceResponse<List<ProjeDetayRaporuDto>>> ProjeDetayRaporu(ProjeDetayRaporuReq request)
        {
            try
            {
                return new ServiceResponse<List<ProjeDetayRaporuDto>>()
                {
                    Value = await RaporService.ProjeDetayRaporu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<ProjeDetayRaporuDto>>();
                e.SetException(ex);
                return e;
            }
        }


    }
}
