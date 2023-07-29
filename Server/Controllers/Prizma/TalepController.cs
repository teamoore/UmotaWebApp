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
    public class TalepController : ControllerBase
    {
        private readonly ITalepDetayService _talepDetayService;
        private readonly ITalepFisService _talepFisService;
        private readonly IMahalService _mahalService;
        private readonly IMapper _mapper;
        public ILogger<TalepController> Logger { get; }

        public TalepController(ITalepDetayService talepDetayService, IMapper mapper, IMahalService mahalService, ILogger<TalepController> logger, ITalepFisService talepFisService)
        {
            _talepDetayService = talepDetayService;
            _mapper = mapper;
            _mahalService = mahalService;
            Logger = logger;
            _talepFisService = talepFisService;
        }

        [HttpPost("CreateTalepFis")]
        public async Task<ServiceResponse<TalepFisDto>> CreateTalepDetay(TalepFisRequestDto request)
        {
            var result = new ServiceResponse<TalepFisDto>();
            try
            {
                var response = await _talepFisService.CreateTalepFis(request.TalepFis);
                var tdDto = _mapper.Map<TalepFis, TalepFisDto>(response);
                result.Value = tdDto;

            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);                 
                result.SetException(ex);
            }

            return result;
        }

        [HttpPost("GetTalepFisList")]
        public async Task<ServiceResponse<List<TalepFisDto>>> GetTalepDetayListAsnyc(TalepFisRequestDto request)
        {
            var result = new ServiceResponse<List<TalepFisDto>>();
            try
            {
                var response = await _talepFisService.GetTalepFisListAsync(request);
                result.Value = response;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
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
                result.SetException(ex);
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
                result.SetException(ex);
 
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
