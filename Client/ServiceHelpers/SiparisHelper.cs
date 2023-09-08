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
    public class SiparisHelper : IDataHelper<SiparisDto, SiparisRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public SiparisHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }
        public Task<SiparisDto> DeleteRecord(SiparisDto request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SiparisDto> LoadRecord(int logref)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<SiparisDto>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SiparisDto> SaveRecord(SiparisDto tf)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            var lgfirmano = selectedFirmaDonem.logo_firma.Value;

            tf.LgFirmaNo = lgfirmano;
            tf.insdate = DateTime.Now;
            tf.insuser = kullanicikodu;
            tf.status = 0;

            var request = new SiparisRequestDto();
            request.SiparisDto = tf;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<SiparisDto, SiparisRequestDto>(UrlHelper.SiparisSaveRecord, request, ThrowSuccessException: true);

            return result;
        }

        public async Task<SiparisDto> UpdateRecord(SiparisDto tf)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            tf.upddate = DateTime.Now;
            tf.upduser = kullanicikodu;

            var request = new SiparisRequestDto();
            request.SiparisDto = tf;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<SiparisDto, SiparisRequestDto>(UrlHelper.SiparisUpdateRecord, request, ThrowSuccessException: true);

            return result;
        }

        public async Task<List<SiparisDto>> LoadRecords(SiparisRequestDto request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<V040_Siparis>> LoadRecordsFromView(SiparisRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<V040_Siparis>, SiparisRequestDto>(UrlHelper.SiparisLoadRecordsFromView, request, ThrowSuccessException: true);

            return result;
        }

        public async Task<SiparisDto> LoadRecordFromView(SiparisRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<SiparisDto, SiparisRequestDto>(UrlHelper.SiparisLoadRecordFromView, request, ThrowSuccessException: true);

            return result;
        }
    }
}
