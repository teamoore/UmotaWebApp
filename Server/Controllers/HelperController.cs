using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IRefGenerator RefService;
        private readonly ILogger<HelperController> Logger;
        public HelperController(IRefGenerator refGenerator, ILogger<HelperController> logger)
        {
            RefService = refGenerator;
            Logger = logger;
        }

        [HttpGet("GenerateRef")]
        public async Task<ServiceResponse<string>> GetRowRefNumber(string table)
        {
            try
            {
                if (string.IsNullOrEmpty(table))
                    throw new ApiExcetion("tablo adı boş geldi.Ref üretilemedi !");

                return new ServiceResponse<string>()
                {
                    Value = await RefService.GenerateRowRef(table)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<string>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
