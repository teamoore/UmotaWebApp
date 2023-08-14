using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizma.Core.Services;
using Prizma.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;
using UmotaWebApp.Shared;
using AutoMapper;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService _siparisService;
        private readonly IMapper _mapper;
        private ILogger<SiparisController> Logger { get; }
        public SiparisController(ISiparisService siparisService, IMapper mapper, ILogger<SiparisController> logger)
        {
            _siparisService = siparisService;
            _mapper = mapper;
            Logger = logger;
        }

        [HttpPost("GetV040SiparisList")]
        public async Task<ServiceResponse<List<V040_Siparis>>> GetV040SiparisListsnyc(SiparisViewRequestDto request)
        {
            var result = new ServiceResponse<List<V040_Siparis>>();
            try
            {
                var response = await _siparisService.GetV040_SiparisList(request);
                result.Value = response;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
        }


    }
}
