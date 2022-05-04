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
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CariRaporController : ControllerBase
    {
        public ILogger<ReportController> Logger { get; }
        public ICariRaporService CariRaporService { get; }

        public CariRaporController(ILogger<ReportController> logger, ICariRaporService cariRaporService)
        {
            Logger = logger;
            CariRaporService = cariRaporService;
        }

        [HttpPost("caridurumraporu")]
        public async Task<ServiceResponse<List<CariDurumRaporuDto>>> CariDurumRaporuGetir(CariDurumRaporuRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<CariDurumRaporuDto>>()
                {
                    Value = await CariRaporService.CariDurumRaporu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<CariDurumRaporuDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("carihesapekstresi")]
        public async Task<ServiceResponse<List<CariHesapEkstresiDto>>> CariHesapEkstresiGetir(CariHesapEkstresiRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<CariHesapEkstresiDto>>()
                {
                    Value = await CariRaporService.CariHesapEkstresi(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<CariHesapEkstresiDto>>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
