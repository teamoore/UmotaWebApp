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
        private readonly IMapper _mapper;

        public TalepDetayController(ITalepDetayService talepDetayService, IMapper mapper)
        {
            _talepDetayService = talepDetayService;
            _mapper = mapper;
        }

        [HttpPost("CreateTalepDetay")]
        public async Task<ActionResult<TalepDetay>> CreateTalepDetay(TalepDetayDTO talepDetayDTO)
        {
            var talepDetay = _mapper.Map<TalepDetayDTO, TalepDetay>(talepDetayDTO);
            var musics = await _talepDetayService.CreateTalepDetay(talepDetay);
            
            return Ok(musics);
        }

        [HttpGet("AllTalepDetay")]
        public async Task<ActionResult<TalepDetayDTO>> AllTalepDetay()
        {            
            var musics = await _talepDetayService.GetTalepDetayList();
            var musicResources = _mapper.Map<IEnumerable<TalepDetay>, IEnumerable<TalepDetayDTO>>(musics);

            return Ok(musicResources);
        }
    }
}
