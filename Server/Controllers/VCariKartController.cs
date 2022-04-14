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
    public class VCariKartController : ControllerBase
    {
        public ILogger<VCariKartController> Logger { get; }
        public IVCariKartService VCariKartService { get; }

        public VCariKartController(ILogger<VCariKartController> logger, IVCariKartService cariKartService)
        {
            Logger = logger;
            VCariKartService = cariKartService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<VCariKartDto>>> GetVCariKartss(string firmaId)
        {
            try
            {
                return new ServiceResponse<List<VCariKartDto>>()
                {
                    Value = await VCariKartService.GetVCariKarts(firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<VCariKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<VCariKartDto>> GetVCariKartt(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<VCariKartDto>()
                {
                    Value = await VCariKartService.GetVCariKart(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<VCariKartDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<VCariKartDto>>> SearchVCariKartss(VCariKartsRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<VCariKartDto>>()
                {
                    Value = await VCariKartService.SearchVCariKarts(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<VCariKartDto>>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
