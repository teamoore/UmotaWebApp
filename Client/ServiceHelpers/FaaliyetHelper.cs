using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;


namespace UmotaWebApp.Client.ServiceHelpers
{
    public class FaaliyetHelper : IDataHelper<FaaliyetDto, FaaliyetRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public FaaliyetHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<FaaliyetDto> LoadRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<FaaliyetDto>(UrlHelper.FaaliyetGetir + "?logref=" + logref + "&firmaId=" + selectedFirmaDonem.firma_no);

            result.FaaliyetSaati = result.Tarih.Value.GetTime();

            return result;
        }

        public async Task<List<FaaliyetDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var request = new FaaliyetRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<FaaliyetDto>, FaaliyetRequestDto>(UrlHelper.FaaliyetAra, request);

            return result;
        }

        public async Task<List<FaaliyetDto>> LoadRecords(FaaliyetRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<FaaliyetDto>, FaaliyetRequestDto>(UrlHelper.FaaliyetAra, request);

            return result;
        }

        public async Task<FaaliyetDto> SaveRecord(FaaliyetDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Insdate = DateTime.Now;
            recordDto.Insuser = kullanicikodu;
            recordDto.Status = 0;
            recordDto.Giren = kullanicikodu;
            recordDto.Tarih = recordDto.Tarih.Value.ChangeTime(recordDto.FaaliyetSaati);

            var request = new FaaliyetRequestDto();
            request.Faaliyet = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<FaaliyetDto, FaaliyetRequestDto>(UrlHelper.FaaliyetKaydet, request);

            return result;
        }

        public async Task<FaaliyetDto> UpdateRecord(FaaliyetDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            recordDto.Status = 1;
            recordDto.Tarih = recordDto.Tarih.Value.ChangeTime(recordDto.FaaliyetSaati);

            var request = new FaaliyetRequestDto();
            request.Faaliyet = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<FaaliyetDto, FaaliyetRequestDto>(UrlHelper.FaaliyetGuncelle, request);

            return result;
        }

        public async Task<FaaliyetDto> DeleteRecord(FaaliyetDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = kullanicikodu;
            recordDto.Status = 2;

            var request = new FaaliyetRequestDto();
            request.Faaliyet = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<FaaliyetDto, FaaliyetRequestDto>(UrlHelper.FaaliyetGuncelle, request);

            return result;
        }

    }
}
