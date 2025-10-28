using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ISisMenuService
    {
        public Task<List<SisMenuDto>> GetSisMenuler();
        public Task<List<MenuItemDto>> GetMenuItems(string kullaniciKodu);

        public Task<List<MenuItemDto>> GetAllMenusAsync();
        public Task<List<KullaniciMenuYetkiDto>> GetUserPermissionsAsync(string kullaniciKodu);
        public Task<bool> SavePermissionsAsync(string kullaniciKodu, List<KullaniciMenuYetkiDto> yetkiler);
    }
}
