using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class AktiviteHelper : IDataHelper<V001Aktivite, AktiviteRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public AktiviteHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<V001Aktivite> DeleteRecord(V001Aktivite request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V001Aktivite> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<V001Aktivite>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new AktiviteRequestDto();
            
            var result = await httpClient.PostGetServiceResponseAsync<List<V001Aktivite>, AktiviteRequestDto>(UrlHelper.AktiviteTumListe, request);

            return result;
        }

        public async Task<List<V001Aktivite>> LoadRecords(AktiviteRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.PostGetServiceResponseAsync<List<V001Aktivite>, AktiviteRequestDto>(UrlHelper.AktiviteBagliListe, request);

            return result;
        }

        public Task<V001Aktivite> SaveRecord(V001Aktivite request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V001Aktivite> UpdateRecord(V001Aktivite request)
        {
            throw new System.NotImplementedException();
        }
    }
}
