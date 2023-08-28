using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class KaynakHelper : IDataHelper<V002_Kaynak, KaynakRequestDto>
    {

        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public KaynakHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<V002_Kaynak> DeleteRecord(V002_Kaynak request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V002_Kaynak> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }
        public async Task<List<V002_Kaynak>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new KaynakRequestDto();

            var result = await httpClient.PostGetServiceResponseAsync<List<V002_Kaynak>, KaynakRequestDto>(UrlHelper.KaynakGetList, request);

            return result;
        }

        public async Task<List<V002_Kaynak>> LoadRecords(KaynakRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.PostGetServiceResponseAsync<List<V002_Kaynak>, KaynakRequestDto>(UrlHelper.KaynakGetList, request);

            return result;
        }

        public Task<V002_Kaynak> SaveRecord(V002_Kaynak request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V002_Kaynak> UpdateRecord(V002_Kaynak request)
        {
            throw new System.NotImplementedException();
        }

    }
}
