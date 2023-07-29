using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;

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

        public Task<List<TalepFisDto>> LoadRecords()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TalepFisDto>> LoadRecords(TalepFisRequestDto request)
        {
            throw new System.NotImplementedException();
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
    }
}
