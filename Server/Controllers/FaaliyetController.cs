using Microsoft.AspNetCore.Authorization;
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

    public class FaaliyetController : ControllerBase
    {
        public ILogger<FaaliyetController> Logger { get; }
        public IFaaliyetService FaaliyetService { get; set; }

        public FaaliyetController(ILogger<FaaliyetController> logger, IFaaliyetService faaliyetService)
        {
            Logger = logger;
            FaaliyetService = faaliyetService;
        }

        [HttpGet("list")]
        public async Task<ServiceResponse<List<FaaliyetDto>>> GetFaaliyetList(string firmaId, string kullanicikodu)
        {
            try
            {
                return new ServiceResponse<List<FaaliyetDto>>()
                {
                    Value = await FaaliyetService.GetFaaliyets(firmaId, kullanicikodu)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<FaaliyetDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<FaaliyetDto>> GetFaaliyet(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<FaaliyetDto>()
                {
                    Value = await FaaliyetService.GetFaaliyetByRef(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<FaaliyetDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<FaaliyetDto>>> SearchFaaliyetList(FaaliyetRequestDto faaliyet)
        {
            try
            {
                return new ServiceResponse<List<FaaliyetDto>>()
                {
                    Value = await FaaliyetService.SearchFaaliyet(faaliyet)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<FaaliyetDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<FaaliyetDto>> SaveFaaliyett(FaaliyetRequestDto request)
        {
            try
            {
                return new ServiceResponse<FaaliyetDto>()
                {
                    Value = await FaaliyetService.SaveFaaliyet(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<FaaliyetDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<FaaliyetDto>> UpdateFaaliyett(FaaliyetRequestDto request)
        {
            try
            {
                return new ServiceResponse<FaaliyetDto>()
                {
                    Value = await FaaliyetService.UpdateFaaliyet(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<FaaliyetDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("getcarifaaliyetsayisi")]
        public async Task<ServiceResponse<int>> GetCariFaaliyetSay(FaaliyetRequestDto faaliyet)
        {
            try
            {
                return new ServiceResponse<int>()
                {
                    Value = await FaaliyetService.GetCariFaaliyetSayisi(faaliyet)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<int>();
                e.SetException(ex);
                return e;
            }
        }


    }
}
