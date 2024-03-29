﻿using Microsoft.AspNetCore.Mvc;
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
    public class TakvimController : ControllerBase
    {
        public ILogger<CariKartController> Logger { get; }
        public ITakvimService takvimService { get; set; }

        public TakvimController(ILogger<CariKartController> logger, ITakvimService takvimService)
        {
            Logger = logger;
            this.takvimService = takvimService;
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<TakvimDto>> TakvimBilgileriniKaydet(TakvimRequestDto request)
        {
            try
            {
                return new ServiceResponse<TakvimDto>()
                {
                    Value = await takvimService.SaveTakvim(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TakvimDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("list")]
        public async Task<ServiceResponse<List<TakvimDto>>> TakvimBilgileriniGetir(TakvimRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<TakvimDto>>()
                {
                    Value = await takvimService.GetTakvimInformation(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<TakvimDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<TakvimDto>> TakvimBilgileriniGuncelle(TakvimRequestDto request)
        {
            try
            {
                return new ServiceResponse<TakvimDto>()
                {
                    Value = await takvimService.UpdateTakvim(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TakvimDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<TakvimDto>> TakvimBilgiGetir(short firmaId, int logref)
        {
            try
            {
                return new ServiceResponse<TakvimDto>()
                {
                    Value = await takvimService.GetTakvim(firmaId,logref)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<TakvimDto>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
