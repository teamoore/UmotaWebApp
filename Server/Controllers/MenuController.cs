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
        public async Task<ServiceResponse<List<MenuItemDto>>> GetMenuItems(string kullaniciKodu)
        {
            try
            {
                return new ServiceResponse<List<MenuItemDto>>()
                {
                    Value = await _sisMenuService.GetMenuItems(kullaniciKodu)
                };
            }
            catch (ApiException ex)
            {
                _logger.LogError("Menüleri çekenken hata oluştu : " + ex.InnerException);

                var e = new ServiceResponse<List<MenuItemDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetAllMenusAsync")]
        public async Task<ServiceResponse<List<MenuItemDto>>> GetAllMenusAsync()
        {
            try
            {
                return new ServiceResponse<List<MenuItemDto>>()
                {
                    Value = await _sisMenuService.GetAllMenusAsync()
                };
            }
            catch (ApiException ex)
            {
                _logger.LogError("Menüleri çekenken hata oluştu : " + ex.InnerException);

                var e = new ServiceResponse<List<MenuItemDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetUserPermissionsAsync")]
        public async Task<ServiceResponse<List<KullaniciMenuYetkiDto>>> GetUserPermissionsAsync(string kullaniciKodu)
        {
            try
            {
                return new ServiceResponse<List<KullaniciMenuYetkiDto>>()
                {
                    Value = await _sisMenuService.GetUserPermissionsAsync(kullaniciKodu)
                };
            }
            catch (ApiException ex)
            {
                _logger.LogError("Menüleri çekenken hata oluştu : " + ex.InnerException);

                var e = new ServiceResponse<List<KullaniciMenuYetkiDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpPost("SavePermissionsAsync")]
        public async Task<ServiceResponse<bool>> SavePermissionsAsync(KullaniciMenuYetkiPostDto request)
        {
            try
            {
                return new ServiceResponse<bool>()
                {
                    Value = await _sisMenuService.SavePermissionsAsync(request.KullaniciKodu, request.Menuler)
                };
            }
            catch (ApiException ex)
            {
                _logger.LogError("Menüleri çekenken hata oluştu : " + ex.InnerException);

                var e = new ServiceResponse<bool>();
                e.SetException(ex);
                return e;
            }
        }


    }
}
