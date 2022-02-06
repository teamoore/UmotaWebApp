using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public ILogger<MenuController> _logger { get; }
        public ISisMenuService _sisMenuService { get; }

        public MenuController(ILogger<MenuController> logger, ISisMenuService sisMenuService)
        {
            _logger = logger;
            _sisMenuService = sisMenuService;
        }

        [HttpGet("List")]
        public async Task<ServiceResponse<List<SisMenuDto>>> GetMenuler()
        {
            try
            {
                return new ServiceResponse<List<SisMenuDto>>()
                {
                    Value = await _sisMenuService.GetSisMenuler()
                };
            }
            catch (ApiException ex)
            {
                _logger.LogError("Menüleri çekenken hata oluştu : " + ex.InnerException);

                var e = new ServiceResponse<List<SisMenuDto>>();
                e.SetException(ex);
                return e;
            }
        }
    }
}
