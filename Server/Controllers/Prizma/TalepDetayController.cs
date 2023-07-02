using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalepDetayController : ControllerBase
    {
        private readonly ITalepDetayService _talepDetayService;
        private readonly IMahalService _mahalService;
        private readonly IMapper _mapper;

        public TalepDetayController(ITalepDetayService talepDetayService, IMapper mapper, IMahalService mahalService)
        {
            _talepDetayService = talepDetayService;
            _mapper = mapper;
            _mahalService = mahalService;
        }

        [HttpPost("CreateTalepDetay")]
        public async Task<ActionResult<TalepDetay>> CreateTalepDetay(TalepDetayDTO talepDetayDTO)
        {
            var talepDetay = _mapper.Map<TalepDetayDTO, TalepDetay>(talepDetayDTO);
            var response = await _talepDetayService.CreateTalepDetay(talepDetay);
            
            return Ok(response);
        }

        [HttpGet("AllTalepDetay")]
        public async Task<ActionResult<TalepDetayDTO>> AllTalepDetay()
        {            
            var td = await _talepDetayService.GetTalepDetayList();
            var m = await _mahalService.GetMahalsList();

            var tdList = _mapper.Map<IEnumerable<TalepDetay>, IEnumerable<TalepDetayDTO>>(td);

            return Ok(tdList);
        }
    }
}
