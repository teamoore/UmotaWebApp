using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prizma.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using UmotaWebApp.Shared.ServiceResponses;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Controllers.Prizma
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaynakController : ControllerBase
    {
        private IKaynakService _kaynakService;

        public KaynakController(IKaynakService kaynakService)
        {
            _kaynakService = kaynakService;
        }

        [HttpPost("GetList")]
        public async Task<ServiceResponse<List<V002_Kaynak>>> GetList(KaynakRequestDto request)
        {
            var result = new ServiceResponse<List<V002_Kaynak>>();
            try
            {
                var list = await _kaynakService.GetList(request);

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
