using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class ServisHelper : IDataHelper<ServisDto, ServisRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public ServisHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<ServisDto> LoadRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<ServisDto>(UrlHelper.ServisGetir + "?logref=" + logref + "&firmaId=" + selectedFirmaDonem.firma_no);

            return result;
        }

        public async Task<List<ServisDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var request = new ServisRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<ServisDto>, ServisRequestDto>(UrlHelper.ServisAra, request);

            return result;
        }

        public async Task<List<ServisDto>> LoadRecords(ServisRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.kullanicikodu = kullanicikodu;

            var result = await httpClient.PostGetServiceResponseAsync<List<ServisDto>, ServisRequestDto>(UrlHelper.ServisAra, request);

            return result;
        }

        public async Task<ServisDto> SaveRecord(ServisDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Insdate = DateTime.Now;
            recordDto.Insuser = kullanicikodu;
            recordDto.Status = 0;

            var request = new ServisRequestDto();
            request.Servis = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisDto, ServisRequestDto>(UrlHelper.ServisKaydet, request);

            return result;
        }

        public async Task<ServisDto> UpdateRecord(ServisDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            recordDto.Status = 1;

            var request = new ServisRequestDto();
            request.Servis = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisDto, ServisRequestDto>(UrlHelper.ServisGuncelle, request);

            return result;
        }

        public async Task<ServisDto> DeleteRecord(ServisDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = kullanicikodu;
            recordDto.Status = 2;

            var request = new ServisRequestDto();
            request.Servis = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisDto, ServisRequestDto>(UrlHelper.ServisGuncelle, request);

            return result;
        }
        public async Task<List<ServisMalzemeDto>> LoadMalzemeler(int servisref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<List<ServisMalzemeDto>>(UrlHelper.ServisMalzemelerGetir + "?servisref=" + servisref + "&firmaId=" + selectedFirmaDonem.firma_no);

            return result;
        }

        public async Task<ServisMalzemeDto> LoadMalzemeRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.GetServiceResponseAsync<ServisMalzemeDto>(UrlHelper.ServisMalzemeGetir + "?logref=" + logref + "&firmaId=" + selectedFirmaDonem.firma_no);

            return result;
        }

        public async Task<ServisMalzemeDto> SaveMalzemeRecord(ServisMalzemeDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Insdate = DateTime.Now;
            recordDto.Insuser = kullanicikodu;
            recordDto.Status = 0;

            var request = new ServisMalzemeRequestDto();
            request.ServisMalzeme = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisMalzemeDto, ServisMalzemeRequestDto>(UrlHelper.ServisMalzemeKaydet, request);

            return result;
        }

        public async Task<ServisMalzemeDto> UpdateMalzemeRecord(ServisMalzemeDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);
            recordDto.Status = 1;

            var request = new ServisMalzemeRequestDto();
            request.ServisMalzeme = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisMalzemeDto, ServisMalzemeRequestDto>(UrlHelper.ServisMalzemeGuncelle, request);

            return result;
        }

        public async Task<ServisMalzemeDto> DeleteMalzemeRecord(ServisMalzemeDto recordDto)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            recordDto.Upddate = DateTime.Now;
            recordDto.Upduser = kullanicikodu;
            recordDto.Status = 2;

            var request = new ServisMalzemeRequestDto();
            request.ServisMalzeme = recordDto;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<ServisMalzemeDto, ServisMalzemeRequestDto>(UrlHelper.ServisMalzemeGuncelle, request);

            return result;
        }
    }
}
