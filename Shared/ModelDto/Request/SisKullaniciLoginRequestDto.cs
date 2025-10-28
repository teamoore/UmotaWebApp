using System;
using System.ComponentModel.DataAnnotations;
namespace UmotaWebApp.Shared.ModelDto
{
    public class SisKullaniciLoginRequestDto
    {
        [Required(ErrorMessage = "Kullanıcı Kodu boş geçilemez")]
        public string Kod { get; set; }
        
        //[Required(ErrorMessage = "Şifre boş geçilemez")] 
        public string Sifre { get; set; }
    }
}
