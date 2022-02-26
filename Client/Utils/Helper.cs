using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class Helper
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        public Helper(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        public async Task<string> GenerateRowRef(string tableName, string keyField)
        {
            var result2 = await httpClient.GetServiceResponseAsync<string>("/api/helper/GenerateRef?table="+ tableName +"&keyField=" + keyField);
            return result2;
        }

        public async Task<int> GenerateRefNumber(string tableName)
        {
            var result2 = await httpClient.GetServiceResponseAsync<int>("/api/helper/RefNoAl?tablename=" + tableName);
            return result2;
        }

    }
}
