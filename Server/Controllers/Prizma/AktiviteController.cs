using Microsoft.AspNetCore.Mvc;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers.Prizma
{
    [Route("api/[controller]")]
    [ApiController]
    public class AktiviteController : ControllerBase
    {
        private IAktiviteService _aktiviteService;

        public AktiviteController(IAktiviteService aktiviteService)
        {
            _aktiviteService = aktiviteService;
        }

        [HttpPost("GetAll")]
        public async Task<ServiceResponse<List<V001Aktivite>>> GetAll()
        {
            var result = new ServiceResponse<List<V001Aktivite>>();
            try
            {
                var list = await _aktiviteService.GetAll();
              
                result.Value = list.ToList();

            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;

        }

        [HttpPost("GetRelated")]
        public async Task<ServiceResponse<List<V001Aktivite>>> GetRelated(AktiviteRequestDto request)
        {
            var result = new ServiceResponse<List<V001Aktivite>>();
            try
            {
                var list = await _aktiviteService.GetRelated(request.ParLogRef);

                result.Value = list.ToList();

            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;

        }
    }
}
