using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UmotaWebApp.Client.Utils;
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
    }
}
