using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizma.Core.Model;
using Prizma.Core.Services;
using Prizma.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;
using System.Linq;

namespace UmotaWebApp.Server.Controllers.Prizma
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjeController : ControllerBase
    {
        private IProjeService _projeService;
        private readonly IMapper _mapper;
        public ILogger<TalepController> _logger { get; }

        public ProjeController(IProjeService projeService, IMapper mapper, ILogger<TalepController> logger)
        {
            _projeService = projeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("GetProjeList")]
        public async Task<ServiceResponse<List<ProjeDto>>> GetAvailableProjeList(ProjeRequestDto request)
        {
            var result = new ServiceResponse<List<ProjeDto>>();
            try
            {
                var list = await _projeService.GetAvailableProjeList();
                var tdList = _mapper.Map<IEnumerable<Proje>, IEnumerable<ProjeDto>>(list);

                result.Value = tdList.ToList();

            }
            catch (ApiException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                result.SetException(ex);

            }
            catch (Exception ex)
            {
                result.SetException(ex);
                _logger.Log(LogLevel.Error, ex.Message);
            }

            return result;

        }

    }
}
