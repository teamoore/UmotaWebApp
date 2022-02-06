using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace MyFirstBlazorApp.Client.Utils
{
    public static class LocalStorageExtensions
    {
        /*
        public async static Task<Guid> GetKullaniciId(this ILocalStorageService localStorageService)
        {
            string kullaniciIdStr = await localStorageService.GetItemAsStringAsync("KullaniciId");

            return Guid.TryParse(kullaniciIdStr.Replace("\"",""), out Guid KullaniciId) ? KullaniciId : Guid.Empty;
        }

        public async static Task<Guid> GetKulupId(this ILocalStorageService localStorageService)
        {
            string kulupIdstr = await localStorageService.GetItemAsStringAsync("KulupId");

            return Guid.TryParse(kulupIdstr.Replace("\"",""), out Guid KulupId) ? KulupId : Guid.Empty;
        }
        */
    }
}
