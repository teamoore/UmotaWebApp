using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DovizController : ControllerBase   
    {
        private readonly IDovizService dovizService;
        private readonly ILogger<DovizController> Logger;

        public DovizController(IDovizService dovizService, ILogger<DovizController> logger)
        {
            this.dovizService = dovizService;
            Logger = logger;
        }

        [HttpGet("GetDovizList")]
        public async Task<ServiceResponse<IEnumerable<DovizDto>>> GetDovizListesi(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<DovizDto>>()
                {
                    Value = await dovizService.GetDovizList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<DovizDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetDovizKur")]
        public async Task<ServiceResponse<double>> GetirDovizKur(int logofirmno, int dovizturu, int kurturu, DateTime kurtarihi)
        {
            try
            {
                return new ServiceResponse<double>()
                {
                    Value = await dovizService.LogoDovKurAl(logofirmno, dovizturu, kurturu, kurtarihi)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<double>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
