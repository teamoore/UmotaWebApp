using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        public ILogger<ReportController> Logger { get; }
        public ITeklifReportService TeklifReportService { get; }

        public ReportController(ILogger<ReportController> logger, ITeklifReportService teklifReportService)
        {
            Logger = logger;
            TeklifReportService = teklifReportService;
        }

        [HttpGet("KacAdetMusteriOnayiBekliyorTeklifVar")]
        public async Task<ServiceResponse<int>> MusteriOnayiBekliyorTeklifSayisi(string firmaId, string kullanici)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await TeklifReportService.KacAdetMusteriOnayiBekliyorTeklifVar(firmaId,kullanici)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<int>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
