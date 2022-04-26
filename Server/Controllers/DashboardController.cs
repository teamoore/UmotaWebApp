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
    public class DashboardController : ControllerBase
    {
        public ILogger<DashboardController> Logger { get; }
        public IDashboardInfo dashboardInfoService { get; }
        public DashboardController(ILogger<DashboardController> logger, IDashboardInfo dashboardInfo)
        {
            Logger = logger;
            this.dashboardInfoService = dashboardInfo;
        }

        [HttpGet("personelteklif")]
        public async Task<ServiceResponse<IEnumerable<PersonelTeklifSatisDto>>> CariKartListele(string firmaId, int? year)
        {
            try
            {
                return new ServiceResponse<IEnumerable<PersonelTeklifSatisDto>>()
                {
                    Value = await dashboardInfoService.GetPersonelTeklifSatis(firmaId,year)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<PersonelTeklifSatisDto>>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
