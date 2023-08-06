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
    public class TalepDetayHelper : IDataHelper<TalepDetayDTO, TalepDetayRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public TalepDetayHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<TalepDetayDTO> DeleteRecord(TalepDetayDTO request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TalepDetayDTO> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TalepDetayDTO>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TalepDetayDTO>> LoadRecords(TalepDetayRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

  
            var result = await httpClient.PostGetServiceResponseAsync<List<TalepDetayDTO>, TalepDetayRequestDto>(UrlHelper.TalepDetayListesi, request);

            return result;
        }

        public async Task<List<V031_TalepDetay>> LoadViewRecords(TalepFisDetayRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var result = await httpClient.PostGetServiceResponseAsync<List<V031_TalepDetay>, TalepFisDetayRequestDto>(UrlHelper.TalepV031TalepDetayList, request);

            return result;
        }

        public async Task<TalepDetayDTO> SaveRecord(TalepDetayDTO td)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            td.insdate = DateTime.Now;
            td.insuser = kullanicikodu;
            td.status = 0;

            var request = new TalepDetayRequestDto();
            request.TalepDetay = td;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TalepDetayDTO, TalepDetayRequestDto>(UrlHelper.TalepDetayKaydet, request, ThrowSuccessException:true);

            return result;
        }

        public Task<TalepDetayDTO> UpdateRecord(TalepDetayDTO request)
        {
            throw new System.NotImplementedException();
        }
    }
}
