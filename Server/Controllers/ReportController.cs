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
using UmotaWebApp.Shared.ModelDto.Request;

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

        [HttpPost("siparisraporu")]
        public async Task<ServiceResponse<List<SiparisRaporuDto>>> SiparisRaporuGetir(SiparisRaporuRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<SiparisRaporuDto>>()
                {
                    Value = await TeklifReportService.SiparisRaporu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<SiparisRaporuDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("tahsilatraporu")]
        public async Task<ServiceResponse<List<TahsilatRaporuDto>>> TahsilatRaporuGetir(TahsilatRaporuRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<TahsilatRaporuDto>>()
                {
                    Value = await TeklifReportService.TahsilatRaporu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TahsilatRaporuDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("bankadurumraporu")]
        public async Task<ServiceResponse<List<BankaDurumRaporuDto>>> BankaDurumRaporuGetir(BankaDurumRaporuRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<BankaDurumRaporuDto>>()
                {
                    Value = await TeklifReportService.BankaDurumRaporu(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<BankaDurumRaporuDto>>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
