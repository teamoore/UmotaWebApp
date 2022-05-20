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
    public class KullaniciHelper
    {
        protected HttpClient httpClient { get; set; }
        protected ILocalStorageService LocalStorageService { get; set; }

        public KullaniciHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<List<SisKullaniciDto>> TumListe()
        {
            var result = await httpClient.GetServiceResponseAsync<List<SisKullaniciDto>>(UrlHelper.GetKullaniciListesi);
            return result;
        }
    }
}
