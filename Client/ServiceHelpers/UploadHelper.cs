using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
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
    public class UploadHelper
    {
        protected HttpClient httpClient { get; set; }

        protected ILocalStorageService LocalStorageService { get; set; }

        public UploadHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<FileUploadDto> Upload(FileDataDto file)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var result = await httpClient.PostGetServiceResponseAsync<FileUploadDto, FileDataDto>(UrlHelper.FileUpload2, file);

            return result;
        }

        public async Task<ImageDataDto> Save(FileUploadRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            request.File.Insuser = kullanicikodu;

            var refno = await httpClient.GetServiceResponseAsync<int>(UrlHelper.RefNoAl + "?tablename=imagedata"  + "&firmaId=" + selectedFirmaDonem.firma_no.Value);
            request.File.LogRef = refno;
            
            var result = await httpClient.PostGetServiceResponseAsync<ImageDataDto, FileUploadRequestDto>(UrlHelper.FileSave, request);

            return result;
        }

        public async Task<List<ImageDataDto>> GetList(FileUploadRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;

            var result = await httpClient.PostGetServiceResponseAsync<List<ImageDataDto>, FileUploadRequestDto>(UrlHelper.FileGetList, request);

            return result;
        }

        public async Task<bool> DeleteFile(FileUploadRequestDto request)
        {
            var selectedFirmaDonem = await LocalStorageService.GetItemAsync<SisFirmaDonemDto>(Consts.FirmaDonem);
            if (selectedFirmaDonem == null)
                throw new Exception("Firma Dönem Seçili değil");

            var kullanicikodu = await LocalStorageService.GetItemAsync<string>(Consts.KullaniciKodu);

            request.FirmaId = selectedFirmaDonem.firma_no.Value;
            
            var result = await httpClient.PostGetServiceResponseAsync<bool, FileUploadRequestDto>(UrlHelper.FileDelete, request);

            return result;
        }
    }
}
