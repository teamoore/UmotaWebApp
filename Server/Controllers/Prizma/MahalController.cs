using Microsoft.AspNetCore.Mvc;
using Prizma.Core.Services;
using Prizma.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto.Request;
using Prizma.Core.Model;
using System.Linq;
using AutoMapper;

namespace UmotaWebApp.Server.Controllers.Prizma
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahalController : ControllerBase
    {
        private IMahalService mahalService;
        private readonly IMapper _mapper;

        public MahalController(IMahalService mahalService, IMapper mapper)
        {
            this.mahalService = mahalService;
            _mapper = mapper;
        }

        [HttpPost("GetMahals")]
        public async Task<ServiceResponse<List<V005Mahal>>> GetMahals(MahalRequestDto request)
        {
            var result = new ServiceResponse<List<V005Mahal>>();
            try
            {
                var list = await mahalService.GetMahals(request.TurRef,request.ProjeRef);

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
