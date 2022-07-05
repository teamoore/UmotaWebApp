using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class VazifeHelper : IDataHelper<VazifeDto, VazifeRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public VazifeHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<VazifeDto> DeleteRecord(VazifeDto request)
        {
            request.Status = 2;
            request.Upddate = DateTime.Now;
            request.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var result = await UpdateRecord(request);
            return result;
        }

        public async Task<VazifeDto> LoadRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            var result = await httpClient.GetServiceResponseAsync<VazifeDto>(UrlHelper.VazifeGetir + "?firmaId=" + selectedFirmaDonem.firma_no.Value.ToString()
                + "&logref=" + logref);

            return result;
        }

        public async Task<List<VazifeDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var request = new VazifeRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.User = kullanicikodu;

            var records = await httpClient.PostGetServiceResponseAsync<List<VazifeDto>, VazifeRequestDto>(UrlHelper.VazifeListesi, request);

            return records;
        }

        public async Task<List<VazifeDto>> LoadRecords(VazifeRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.User = kullanicikodu;

            var records = await httpClient.PostGetServiceResponseAsync<List<VazifeDto>, VazifeRequestDto>(UrlHelper.VazifeListesi, request);

            return records;
        }

        public async Task<VazifeDto> SaveRecord(VazifeDto vazife)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            vazife.Insdate = DateTime.Now;
            vazife.Insuser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            vazife.Status = 0;

            var request = new VazifeRequestDto();
            request.Vazife = vazife;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<VazifeDto, VazifeRequestDto>(UrlHelper.VazifeKaydet, request);

            return result;
        }

        public async Task<int> CountRecords(VazifeRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.User = kullanicikodu;

            var records = await httpClient.PostGetServiceResponseAsync<int, VazifeRequestDto>(UrlHelper.VazifeSayisi, request);

            return records;
        }

        public async Task<VazifeDto> UpdateRecord(VazifeDto vazife)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var request = new VazifeRequestDto();
            request.Vazife = vazife;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<VazifeDto, VazifeRequestDto>(UrlHelper.VazifeGuncelle, request);

            return result;
        }
    }
}
