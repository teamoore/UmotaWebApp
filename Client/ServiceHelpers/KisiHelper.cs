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
    public class KisiHelper : IDataHelper<KisilerDto, KisilerRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public KisiHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<KisilerDto> DeleteRecord(KisilerDto request)
        {
            throw new NotImplementedException();
        }

        public Task<KisilerDto> LoadRecord(int logref)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KisilerDto>> LoadRecords(int CariRef)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            var result = await httpClient.GetServiceResponseAsync<List<KisilerDto>>(UrlHelper.CariKartKisiGetir + "?cariref=" + CariRef + "&firmaId=" + selectedFirmaDonem.firma_no);

            return result;
        }

        public Task<List<KisilerDto>> LoadRecords(KisilerRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<KisilerDto> SaveRecord(KisilerDto request)
        {
            throw new NotImplementedException();
        }

        public Task<KisilerDto> UpdateRecord(KisilerDto request)
        {
            throw new NotImplementedException();
        }

        public Task<List<KisilerDto>> LoadRecords()
        {
            throw new NotImplementedException();
        }
    }
}
