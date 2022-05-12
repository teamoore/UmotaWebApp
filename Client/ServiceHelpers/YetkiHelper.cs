using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class YetkiHelper
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public YetkiHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<MenuYetkiDto> GetKullaniciMenuYetkisi(string formName)
        {
            var a = new MenuYetkiDto();
            var kullanici_kodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var result = await httpClient.GetServiceResponseAsync<SisKullaniciDto>(UrlHelper.KullaniciGetByKod + "?kod=" + kullanici_kodu);

            if (result == null)
                return a;

            a.IsAdmin = result.isAdmin;

            if (a.IsAdmin)
                return a;

            var result2 = await httpClient.GetServiceResponseAsync<int>(UrlHelper.KullaniciMenuYetkisi + "?kullanicikodu=" + kullanici_kodu + "&menu_dfm="+ formName +"&hak_tipi=sel");

            a.View = result2 == 1;

            if (a.View)
            {
                result2 = await httpClient.GetServiceResponseAsync<int>(UrlHelper.KullaniciMenuYetkisi + "?kullanicikodu=" + kullanici_kodu + "&menu_dfm=" + formName + "&hak_tipi=ins");
                a.Insert = result2 == 1;

                result2 = await httpClient.GetServiceResponseAsync<int>(UrlHelper.KullaniciMenuYetkisi + "?kullanicikodu=" + kullanici_kodu + "&menu_dfm=" + formName + "&hak_tipi=upd");
                a.Update = result2 == 1;

                result2 = await httpClient.GetServiceResponseAsync<int>(UrlHelper.KullaniciMenuYetkisi + "?kullanicikodu=" + kullanici_kodu + "&menu_dfm=" + formName + "&hak_tipi=del");
                a.Delete = result2 == 1;
            }

            return a;
        }

        public async Task <int>RefNoAl(string tablename)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<int>(UrlHelper.RefNoAl + "?tablename=" + tablename + "&firmaId=" + selectedFirmaDonem.firma_no.Value);
            return result;
        }

    }
}
