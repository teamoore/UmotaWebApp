using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalepController : ControllerBase
    {
        private readonly ITalepDetayService _talepDetayService;
        private readonly ITalepFisService _talepFisService;
        private readonly ITalepOnayService _talepOnayService;
        private readonly IMahalService _mahalService;
        private readonly ITalepDosyaService _talepDosyaService;
        private readonly IMapper _mapper;
        public ILogger<TalepController> Logger { get; }

        public TalepController(ITalepDetayService talepDetayService, IMapper mapper, IMahalService mahalService, ILogger<TalepController> logger, ITalepFisService talepFisService, ITalepOnayService talepOnayService, ITalepDosyaService talepDosyaService)
        {
            _talepDetayService = talepDetayService;
            _mapper = mapper;
            _mahalService = mahalService;
            Logger = logger;
            _talepFisService = talepFisService;
            _talepOnayService = talepOnayService;
            _talepDosyaService = talepDosyaService;
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

        [HttpPost("GetV030TalepFisList")]
        public async Task<ServiceResponse<List<V030_TalepFis>>> GetV030TalepFisListsnyc(TalepFisRequestDto request)
        {
            var result = new ServiceResponse<List<V030_TalepFis>>();
            try
            {
                var response = await _talepFisService.GetV030_TalepFisListAsync(request);
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

        [HttpPost("GetTalepDetay")]
        public async Task<ServiceResponse<TalepDetayDTO>> GetTalepDetay(TalepDetayRequestDto request)
        {
            var result = new ServiceResponse<TalepDetayDTO>();
            try
            {
                var response = await _talepDetayService.GetTalepDetay(request.TalepDetay.logref);
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
        

        [HttpPost("GetTalepFisDetayListAsnyc")]
        public async Task<ServiceResponse<List<V031_TalepDetay>>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request)
        {
            var result = new ServiceResponse<List<V031_TalepDetay>>();
            try
            {
                var td = await _talepDetayService.GetTalepFisDetayListAsnyc(request);

                result.Value = td.ToList();

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

        [HttpPost("UpdateTalepDetay")]
        public async Task<ServiceResponse<TalepDetayDTO>> UpdateTalepDetay(TalepDetayRequestDto request)
        {
            var result = new ServiceResponse<TalepDetayDTO>();
            try
            {
                var response = await _talepDetayService.Update(request);
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

        [HttpPost("GetTalepFisOnayListAsnyc")]
        public async Task<ServiceResponse<List<V032_TalepOnay>>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request)
        {
            var result = new ServiceResponse<List<V032_TalepOnay>>();
            try
            {
                var td = await _talepOnayService.GetTalepFisOnayListAsnyc(request);

                result.Value = td.ToList();

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

        [HttpPost("TalepOnayRota")]
        public async Task<ServiceResponse<int>> TalepOnayRota(TalepOnayRequestDto request)
        {
            var result = new ServiceResponse<int>();

            try
            {
                result.Value = await _talepOnayService.TalepOnayRota(request);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                Logger.Log(LogLevel.Error, ex.Message);
            }

            return result;
        }

        [HttpPost("TalepDurumGuncelle")]
        public async Task<ServiceResponse<int>> TalepDurumGuncelle(TalepOnayRequestDto request)
        {
            var result = new ServiceResponse<int>();

            try
            {
                result.Value = await _talepOnayService.TalepDurumGuncelle(request);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                Logger.Log(LogLevel.Error, ex.Message);
            }

            return result;
        }

        [HttpPost("UploadTalepDosya")]
        public async Task<ServiceResponse<bool>> UploadTalepDosya(TalepDosyaRequestDto request)
        { 
            var result = new ServiceResponse<bool>();

            try
            {
                result.Value = await _talepOnayService.UploadTalepDosya(request);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                Logger.Log(LogLevel.Error, ex.Message);
            }

            return result;
        }

        [HttpPost("GetTalepDosyalar")]
        public async Task<ServiceResponse<List<TalepDosyaDto>>> GetTalepDosyalar([FromBody] int talepref)
        {
            var result = new ServiceResponse<List<TalepDosyaDto>>();

            try
            {
                var response = await _talepDosyaService.GetDosyalar(talepref);
                var td = _mapper.Map<IEnumerable<TalepDosya>, IEnumerable<TalepDosyaDto>>(response);

                result.Value = td.ToList();
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
