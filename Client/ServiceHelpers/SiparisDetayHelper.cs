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
    public class SiparisDetayHelper : IDataHelper<SiparisDetayDto, SiparisDetayRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public SiparisDetayHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<SiparisDetayDto> DeleteRecord(SiparisDetayDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<SiparisDetayDto> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SiparisDetayDto>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SiparisDetayDto>> LoadRecords(SiparisDetayRequestDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<SiparisDetayDto> SaveRecord(SiparisDetayDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<SiparisDetayDto> UpdateRecord(SiparisDetayDto request)
        {
            throw new System.NotImplementedException();
        }
        public async Task<List<V041_SiparisDetay>> LoadViewRecords(SiparisDetayRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var result = await httpClient.PostGetServiceResponseAsync<List<V041_SiparisDetay>, SiparisDetayRequestDto>(UrlHelper.SiparisV041SiparisDetayList, request);

            return result;
        }
    }
}
