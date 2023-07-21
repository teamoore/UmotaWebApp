using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizma.Core.Model;
using Prizma.Core.Services;
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
    public class TalepDetayController : ControllerBase
    {
        private readonly ITalepDetayService _talepDetayService;
        private readonly IMahalService _mahalService;
        private readonly IMapper _mapper;
        public ILogger<TalepDetayController> Logger { get; }

        public TalepDetayController(ITalepDetayService talepDetayService, IMapper mapper, IMahalService mahalService, ILogger<TalepDetayController> logger)
        {
            _talepDetayService = talepDetayService;
            _mapper = mapper;
            _mahalService = mahalService;
            Logger = logger;
        }

        [HttpPost("CreateTalepDetay")]
        public async Task<ServiceResponse<TalepDetayDTO>> CreateTalepDetay(TalepDetayRequestDto request)
        {
            var result = new ServiceResponse<TalepDetayDTO>();
            try
            {
                var response = await _talepDetayService.CreateTalepDetay(request.TalepDetay);
                var tdDto = _mapper.Map<TalepDetay, TalepDetayDTO>(response);
                result.Value = tdDto;

            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TalepDetayDTO>();
                e.SetException(ex);
                return e;
            }

            return result;
        }

        [HttpPost("AllTalepDetay")]
        public async Task<ServiceResponse<List<TalepDetayDTO>>> AllTalepDetay(TalepDetayRequestDto request)
        {
            var result = new ServiceResponse<List<TalepDetayDTO>>();
            try
            {
                var td = await _talepDetayService.GetTalepDetayList();
                var tdList = _mapper.Map<IEnumerable<TalepDetay>, IEnumerable<TalepDetayDTO>>(td);

                result.Value = tdList.ToList();
                 
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TalepDetayDTO>>();
                e.SetException(ex);
                return e;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                Logger.Log(LogLevel.Error, ex.Message);
            }

            return result;
             
        }
    }
}
