using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class TeklifHelper : IDataHelper<TeklifDto, TeklifRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public TeklifHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<TeklifDto> LoadRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<TeklifDto>(UrlHelper.TeklifGetir + "?logref=" + logref + "&firmaId=" + selectedFirmaDonem.firma_no);

            return result;
        }

        public async Task<List<TeklifDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var request = new TeklifRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<TeklifDto>, TeklifRequestDto>(UrlHelper.TeklifAra, request);

            return result;
        }

        public async Task<List<TeklifDto>> LoadRecords(TeklifRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<TeklifDto>, TeklifRequestDto>(UrlHelper.TeklifAra, request);

            return result;
        }

        public async Task<TeklifDto> SaveRecord(TeklifDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Insdate = DateTime.Now;
            recordDto.Insuser = kullanicikodu;
            recordDto.Status = 0;

            var request = new TeklifRequestDto();
            request.Teklif = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.Teklif.Lfirma = selectedFirmaDonem.logo_firma.Value.ToString();
            request.Teklif.Ldonem = selectedFirmaDonem.logo_donem.Value.ToString();

            var result = await httpClient.PostGetServiceResponseAsync<TeklifDto, TeklifRequestDto>(UrlHelper.TeklifKaydet, request);

            return result;
        }

        public async Task<TeklifDto> UpdateRecord(TeklifDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            recordDto.Status = 1;

            var request = new TeklifRequestDto();
            request.Teklif = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TeklifDto, TeklifRequestDto>(UrlHelper.TeklifGuncelle, request);

            return result;
        }

        public async Task<TeklifDto> DeleteRecord(TeklifDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = kullanicikodu;
            recordDto.Status = 2;

            var request = new TeklifRequestDto();
            request.Teklif = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TeklifDto, TeklifRequestDto>(UrlHelper.TeklifGuncelle, request);

            var delete = await httpClient.GetServiceResponseAsync<bool>(UrlHelper.TeklifSil + "?logref=" + recordDto.Logref + "&firmaId=" + selectedFirmaDonem.firma_no.Value + "&kullanici=" + kullanicikodu);

            return result;
        }

    }
}
