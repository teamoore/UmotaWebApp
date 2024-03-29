﻿using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public class TakvimHelper : IDataHelper<TakvimDto, TakvimRequestDto>
    {
        public HttpClient httpClient { get; set; }
        public ILocalStorageService LocalStorageService { get; set; }

        public TakvimHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<TakvimDto> LoadRecord(int logref)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            var result = await httpClient.GetServiceResponseAsync<TakvimDto>(UrlHelper.TakvimGetir + "?firmaId=" + selectedFirmaDonem.firma_no.Value.ToString()
                + "&logref=" + logref);

            result.Saat = result.Tarih.Value.TimeOfDay;

            return result;
        }

        public async Task<List<TakvimDto>> LoadRecords()
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            var request = new TakvimRequestDto();
            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.User = kullanicikodu;

            var takvimler = await httpClient.PostGetServiceResponseAsync<List<TakvimDto>, TakvimRequestDto>(UrlHelper.TakvimListesi, request);

            
            return takvimler;
        }

        public async Task<List<TakvimDto>> LoadRecords(TakvimRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.User = kullanicikodu;

            var takvimler = await httpClient.PostGetServiceResponseAsync<List<TakvimDto>, TakvimRequestDto>(UrlHelper.TakvimListesi, request);

            return takvimler;
        }

        public async Task<TakvimDto> SaveRecord(TakvimDto takvim)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            takvim.Insdate = DateTime.Now;
            if (string.IsNullOrEmpty(takvim.Insuser))
                takvim.Insuser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            if (!takvim.Saat.HasValue)
                takvim.Saat = TimeSpan.FromMinutes(60 * 9); //saat 09:00 default

            takvim.Tarih = takvim.Saat.HasValue ? takvim.Tarih.Value.ChangeTime(takvim.Saat) : takvim.Tarih.Value;
            takvim.Status = 0;

            var request = new TakvimRequestDto();
            request.Takvim = takvim;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TakvimDto, TakvimRequestDto>(UrlHelper.TakvimKaydet, request);

            return result;
        }

        public async Task<TakvimDto> UpdateRecord(TakvimDto takvim)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            takvim.Upddate = DateTime.Now;
            takvim.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            takvim.Tarih = takvim.Tarih.Value.ChangeTime(takvim.Saat);
            takvim.Status = 0;

            var request = new TakvimRequestDto();
            request.Takvim = takvim;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TakvimDto, TakvimRequestDto>(UrlHelper.TakvimGuncelle, request);

            return result;
        }

        public async Task<TakvimDto> DeleteRecord(TakvimDto takvim)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);

            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            takvim.Upddate = DateTime.Now;
            takvim.Upduser = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            takvim.Tarih = takvim.Tarih.Value.ChangeTime(takvim.Saat);
            takvim.Status = 2;

            var request = new TakvimRequestDto();
            request.Takvim = takvim;
            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<TakvimDto, TakvimRequestDto>(UrlHelper.TakvimGuncelle, request);

            return result;
        }

    }
}
