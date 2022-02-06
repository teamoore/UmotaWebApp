using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ModelDto
{
    public class SisKullaniciLoginResponseDto
    {
        public string ApiToken { get; set; }

        public SisKullaniciDto KullaniciDto { get; set; }

        public List<SisFirmaDonemYetkiDto> KullaniciFirmaDonemYetkiListesi { get; set; }
    }
}
