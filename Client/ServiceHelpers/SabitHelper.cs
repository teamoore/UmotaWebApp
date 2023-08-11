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
    public class SabitHelper
    {
        public enum SabitTurler
        {
            TalepTuru = 50,
            TalepTeslimYeri = 52,
            TalepOnayTuru = 54,
            Birimler = 53
        }

        protected HttpClient httpClient { get; set; }

        protected ILocalStorageService LocalStorageService { get; set; }

        public SabitHelper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            LocalStorageService = localStorageService;
        }

        public async Task<List<SisSabitlerDetayDto>> GetSabitDetay(SabitTurler tur)
        {
            var result = new List<SisSabitlerDetayDto>();
            try
            {
                result = await httpClient.GetServiceResponseAsync<List<SisSabitlerDetayDto>>("/api/helper/GetSabitDetayList?tip=" + (int)tur);
               
            }
            catch (Exception)
            {
            }

            return result;
        }

        public async Task<List<V002_Kaynak>> GetKaynakList(int aktivite3LogRef)
        {
            var result = new List<V002_Kaynak>();
            try
            {
                result = await httpClient.GetServiceResponseAsync<List<V002_Kaynak>>("/api/helper/GetKaynakList?aktivite3LogRef=" + aktivite3LogRef);

            }
            catch (Exception)
            {
            }

            return result;
        }

        public async Task<List<SisSabitlerDetayDto>> GetKaynakBirimKoduList(int kaynakLogRef)
        {
            var result = new List<SisSabitlerDetayDto>();
            try
            {
                result = await httpClient.GetServiceResponseAsync<List<SisSabitlerDetayDto>>("/api/helper/GetKaynakBirimKoduList?kaynakLogRef=" + kaynakLogRef);

            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
