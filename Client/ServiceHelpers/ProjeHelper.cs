using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class ProjeHelper : IDataHelper<ProjeDto, ProjeRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public ProjeHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }



        public Task<ProjeDto> DeleteRecord(ProjeDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjeDto> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProjeDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");


            var request = new ProjeRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<List<ProjeDto>, ProjeRequestDto>(UrlHelper.ProjeListesi, request);

            return result;
        }

        public Task<List<ProjeDto>> LoadRecords(ProjeRequestDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjeDto> SaveRecord(ProjeDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjeDto> UpdateRecord(ProjeDto request)
        {
            throw new System.NotImplementedException();
        }
    }
}
