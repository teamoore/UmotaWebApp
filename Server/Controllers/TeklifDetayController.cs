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
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class TeklifDetayController : ControllerBase
    {
        public ILogger<TeklifDetayController> Logger { get; }
        public ITeklifDetayService TeklifDetayService { get; }

        public TeklifDetayController(ILogger<TeklifDetayController> logger, ITeklifDetayService teklifDetayService)
        {
            Logger = logger;
            TeklifDetayService = teklifDetayService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<TeklifDetayDto>>> GetTeklifList(int teklifRef, string firmaId)
        {
            try
            {
                return new ServiceResponse<List<TeklifDetayDto>>()
                {
                    Value = await TeklifDetayService.GetTeklifDetays(teklifRef, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TeklifDetayDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<TeklifDetayDto>> GetTeklifDetay(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<TeklifDetayDto>()
                {
                    Value = await TeklifDetayService.GetTeklifDetay(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDetayDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<TeklifDetayDto>> SaveTeklifDetay(TeklifDetayRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDetayDto>()
                {
                    Value = await TeklifDetayService.SaveTeklifDetay(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDetayDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<TeklifDetayDto>> UpdateTeklifDetay(TeklifDetayRequestDto request)
        {
            try
            {
                return new ServiceResponse<TeklifDetayDto>()
                {
                    Value = await TeklifDetayService.UpdateTeklifDetay(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TeklifDetayDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("delete")]
        public async Task<ServiceResponse<bool>> DeleteTeklifDetay(int logref, string firmaId, string kullanici)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await TeklifDetayService.DeleteTeklifDetay(logref, firmaId, kullanici)
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

        [HttpGet("getsirano")]
        public async Task<ServiceResponse<string>> GetSiraNo(int teklifref, string firmaId)
        {
            try
            {
                return new ServiceResponse<string>()
                {
                    Value = await TeklifDetayService.GetTeklifDetaySiraNo(teklifref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<string>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
