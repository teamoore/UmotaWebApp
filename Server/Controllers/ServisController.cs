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
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServisController : ControllerBase
    {
        public ILogger<ServisController> Logger { get; }
        public IServisService ServisService { get; set; }

        public ServisController(ILogger<ServisController> logger, IServisService servisService)
        {
            Logger = logger;
            ServisService = servisService;
        }

        [HttpGet("get")]
        public async Task<ServiceResponse<ServisDto>> GetServis(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<ServisDto>()
                {
                    Value = await ServisService.GetServisByRef(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("search")]
        public async Task<ServiceResponse<List<ServisDto>>> SearchServisList(ServisRequestDto request)
        {
            try
            {
                return new ServiceResponse<List<ServisDto>>()
                {
                    Value = await ServisService.SearchServis(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<ServisDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("save")]
        public async Task<ServiceResponse<ServisDto>> SaveServis(ServisRequestDto request)
        {
            try
            {
                return new ServiceResponse<ServisDto>()
                {
                    Value = await ServisService.SaveServis(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("update")]
        public async Task<ServiceResponse<ServisDto>> UpdateServis(ServisRequestDto request)
        {
            try
            {
                return new ServiceResponse<ServisDto>()
                {
                    Value = await ServisService.UpdateServis(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("delete")]
        public async Task<ServiceResponse<bool>> DeleteServis(int logref, string firmaId, string kullanici)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await ServisService.DeleteServis(logref, firmaId, kullanici)
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

        [HttpGet("getmalzemeler")]
        public async Task<ServiceResponse<List<ServisMalzemeDto>>> GetServisMalzemeler(int servisref, string firmaId)
        {
            try
            {
                return new ServiceResponse<List<ServisMalzemeDto>>()
                {
                    Value = await ServisService.GetServisMalzemeler(servisref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<ServisMalzemeDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("getmalzeme")]
        public async Task<ServiceResponse<ServisMalzemeDto>> GetServisMalzeme(int logref, string firmaId)
        {
            try
            {
                return new ServiceResponse<ServisMalzemeDto>()
                {
                    Value = await ServisService.GetServisMalzeme(logref, firmaId)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisMalzemeDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("savemalzeme")]
        public async Task<ServiceResponse<ServisMalzemeDto>> SaveServisMalzeme(ServisMalzemeRequestDto request)
        {
            try
            {
                return new ServiceResponse<ServisMalzemeDto>()
                {
                    Value = await ServisService.SaveServisMalzeme(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisMalzemeDto>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("updatemalzeme")]
        public async Task<ServiceResponse<ServisMalzemeDto>> UpdateServisMalzeme(ServisMalzemeRequestDto request)
        {
            try
            {
                return new ServiceResponse<ServisMalzemeDto>()
                {
                    Value = await ServisService.UpdateServisMalzeme(request)
                };
            }
            catch (ApiException ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<ServisMalzemeDto>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
