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
    public class TalepFisHelper : IDataHelper<TalepFisDto, TalepFisRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public TalepFisHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public Task<TalepFisDto> DeleteRecord(TalepFisDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TalepFisDto> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TalepFisDto>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TalepFisDto>> LoadRecords(TalepFisRequestDto request)
        {

            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");
                        
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<TalepFisDto>, TalepFisRequestDto>(UrlHelper.TalepFisListesi, request, ThrowSuccessException: true);

            return result;
        }

        public async Task<TalepFisDto> SaveRecord(TalepFisDto tf)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            tf.insdate = DateTime.Now;
            tf.insuser = kullanicikodu;
            tf.status = 0;

            var request = new TalepFisRequestDto();
            request.TalepFis = tf;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TalepFisDto, TalepFisRequestDto>(UrlHelper.TalepFisKaydet, request, ThrowSuccessException: true);

            return result;
        }

        public Task<TalepFisDto> UpdateRecord(TalepFisDto request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<V030_TalepFis>> LoadRecords_ViewV030TalepFis(TalepFisRequestDto request)
        {

            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<V030_TalepFis>, TalepFisRequestDto>(UrlHelper.TalepV030TalepFisList, request, ThrowSuccessException: true);

            return result;
        }
        public async Task<List<V032_TalepOnay>> GetTalepFisOnayListAsnyc(int talepref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new TalepOnayRequestDto();
            request.TalepRef = talepref;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<V032_TalepOnay>, TalepOnayRequestDto>(UrlHelper.TalepFisOnayListeGetir, request , ThrowSuccessException: true);

            return result;
        }

        public async Task<int> TalepOnayRota(int talepRef)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new TalepOnayRequestDto();
            request.TalepRef = talepRef;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<int, TalepOnayRequestDto>(UrlHelper.TalepOnayRota, request, ThrowSuccessException: true);

            return result;
        }

        public async Task<int> TalepDurumGuncelle(int talepRef)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new TalepOnayRequestDto();
            request.TalepRef = talepRef;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<int, TalepOnayRequestDto>(UrlHelper.TalepDurumGuncelle, request, ThrowSuccessException: true);

            return result;
        }
    }
}
