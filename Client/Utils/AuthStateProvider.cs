using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace UmotaWebApp.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        public AuthStateProvider(ILocalStorageService localStorageService, HttpClient client)
        {
            LocalStorageService = localStorageService;
            Client = client;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public ILocalStorageService LocalStorageService { get; }
        public HttpClient Client { get; }

        private readonly AuthenticationState anonymous;


        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenStr = await LocalStorageService.GetItemAsStringAsync("token");

            if (string.IsNullOrEmpty(tokenStr))
                return anonymous;

            string kkodu = await LocalStorageService.GetItemAsStringAsync("kullanicikodu");

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,kkodu) }, "jwtAuthType"));

            //Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenStr);
            var authStr = $"Bearer " + tokenStr.Replace("\"", "");
            authStr = authStr.Replace("\"", "");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", authStr);

            return new AuthenticationState(cp);
        }

        public void NotifyUserLogin(string email)
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));

            var t = Task.FromResult(new AuthenticationState(cp));

            NotifyAuthenticationStateChanged(t);
        }

        public void NotifyUserLogout()
        {
            var t = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(t);
        }
    }
}
