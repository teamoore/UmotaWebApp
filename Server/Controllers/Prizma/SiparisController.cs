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
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto.Request;
using System.Linq;
using Prizma.Core.Model;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService _siparisService;
        private readonly ISiparisDetayService _siparisDetayService;
        private readonly IMapper _mapper;
        private ILogger<SiparisController> Logger { get; }
        public SiparisController(ISiparisService siparisService, ISiparisDetayService siparisDetayService, IMapper mapper, ILogger<SiparisController> logger)
        {
            _siparisService = siparisService;
            _siparisDetayService = siparisDetayService;
            _mapper = mapper;
            Logger = logger;
        }

        [HttpPost("LoadRecordsFromView")]
        public async Task<ServiceResponse<List<V040_Siparis>>> LoadRecordsFromView(SiparisRequestDto request)
        {
            var result = new ServiceResponse<List<V040_Siparis>>();
            try
            {
                var response = await _siparisService.LoadRecordsFromView(request);
                result.Value = response;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
        }

        [HttpPost("LoadRecordFromView")]
        public async Task<ServiceResponse<SiparisDto>> LoadRecordFromView(SiparisRequestDto request)
        {
            var result = new ServiceResponse<SiparisDto>();
            try
            {
                var response = await _siparisService.LoadRecordFromView(request);
                result.Value = response;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
        }

        [HttpPost("SaveRecord")]
        public async Task<ServiceResponse<SiparisDto>> SaveRecord(SiparisRequestDto request)
        {
            var result = new ServiceResponse<SiparisDto>();
            try
            {
                var response = await _siparisService.SaveRecord(request.SiparisDto);
                
                result.Value = request.SiparisDto;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
        }

        [HttpPost("UpdateRecord")]
        public async Task<ServiceResponse<SiparisDto>> UpdateRecord(SiparisRequestDto request)
        {
            var result = new ServiceResponse<SiparisDto>();
            try
            {
                var response = await _siparisService.UpdateRecord(request.SiparisDto);

                result.Value = request.SiparisDto;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);
            }

            return result;
        }

        [HttpPost("GetSiparisDetayListAsnyc")]
        public async Task<ServiceResponse<List<V041_SiparisDetay>>> GetSiparisDetayListAsnyc(SiparisDetayRequestDto request)
        {
            var result = new ServiceResponse<List<V041_SiparisDetay>>();
            try
            {
                var td = await _siparisDetayService.GetSiparisDetayListAsnyc(request);

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


    }
}
