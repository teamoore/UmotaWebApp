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
    public class MahalHelper : IDataHelper<V005Mahal, MahalRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public MahalHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<V005Mahal> DeleteRecord(V005Mahal request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V005Mahal> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<V005Mahal>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<V005Mahal>> LoadRecords(MahalRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.PostGetServiceResponseAsync<List<V005Mahal>, MahalRequestDto>(UrlHelper.MahalListesi, request);

            return result;
        }

        public Task<V005Mahal> SaveRecord(V005Mahal request)
        {
            throw new System.NotImplementedException();
        }

        public Task<V005Mahal> UpdateRecord(V005Mahal request)
        {
            throw new System.NotImplementedException();
        }
    }
}
