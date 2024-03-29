﻿using Microsoft.AspNetCore.Authorization;
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
    public class TeklifController : ControllerBase
    {
        public ILogger<TeklifController> Logger { get; }
        public ITeklifService TeklifService { get; set; }

        public TeklifController(ILogger<TeklifController> logger, ITeklifService teklifService)
        {
            Logger = logger;
            TeklifService = teklifService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<TeklifDto>>> GetTeklifList(string firmaId, string kullanicikodu, string duruminfo)
        {
            try
            {
                return new ServiceResponse<List<TeklifDto>>()
                {
                    Value = await TeklifService.GetTeklifDtos(firmaId,kullanicikodu, duruminfo)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<TeklifDto>>> SearchTeklifList(TeklifRequestDto teklif)
        {
            try
            {
                return new ServiceResponse<List<TeklifDto>>()
                {
                    Value = await TeklifService.SearchTeklif(teklif)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<TeklifDto>> SaveTeklif(TeklifRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.SaveTeklif(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<TeklifDto>> GetTeklif(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.GetTeklifByRef(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<TeklifDto>> UpdateTeklifDetay(TeklifRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.UpdateTeklif(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("updatedurum")]
        public async Task<ServiceResponse<TeklifDto>> UpdateTeklifDurumu(TeklifRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.UpdateTeklifDurum(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("delete")]
        public async Task<ServiceResponse<bool>> DeleteTeliff(int logref, string firmaId, string kullanici)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await TeklifService.DeleteTeklif(logref, firmaId, kullanici)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<bool>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("teklifdurumlist")]
        public async Task<ServiceResponse<List<TeklifDurumDetayDto>>> TeklifDurumDetayListele(int teklifref, string firmaId)
        {
            try
            {
                return new ServiceResponse<List<TeklifDurumDetayDto>>()
                {
                    Value = await TeklifService.GetTeklifDurumDetay(teklifref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDurumDetayDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("saverevize")]
        public async Task<ServiceResponse<TeklifDto>> SaveTeklifRevize(TeklifRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDto>()
                {
                    Value = await TeklifService.TeklifKopyalaRevizeEt(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDto>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
