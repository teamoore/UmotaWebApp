using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class UrlHelper
    {
        public const string RefNoAl = "/api/helper/RefNoAl";
        public const string FisNoAl = "/api/helper/GenerateRef";
        public const string FisNoAlLogo = "/api/helper/fisnoallogo";

        public const string GetMenuList = "/api/menu/List";
        public const string GetMenuListForUser = "/api/menu/ListForUser";
        public const string GetUserPermissionsAsync = "/api/menu/GetUserPermissionsAsync";
        public const string SavePermissionsAsync = "/api/menu/SavePermissionsAsync";
        public const string GetAllMenusAsync = "/api/menu/GetAllMenusAsync";

        public const string Login = "api/kullanici/login";
        public const string GetKullaniciYetkisi = "api/kullanici/GetKullaniciYetkisi";
        public const string KullaniciGetByKod = "/api/kullanici/GetByKod";
        public const string KullaniciMenuYetkisi = "/api/kullanici/GetKullaniciMenuYetkisi";
        public const string KullaniciSave = "/api/kullanici/save";
        public const string KullaniciUpdate = "/api/kullanici/update";
        public const string GetKullaniciListesi = "/api/kullanici/list";
        public const string GetKullaniciGrupListesi = "/api/kullanici/gruplist";
        public const string GetKullaniciYetkiList = "/api/kullanici/GetKullaniciYetkiList";
        public const string PostKullaniciYetkiList = "/api/kullanici/PostKullaniciYetkiList";

        public const string MalzemeKartListesi = "/api/malzemekart/list";
        public const string MalzemeKartGetir = "/api/malzemekart/get";
        public const string MalzemeKartAra = "/api/malzemekart/search";
        public const string MalzemeFotoGetir = "/api/malzemekart/getfotolist";
        public const string UrunExelAktar = "/api/malzemekart/UrunExcelAktar";

        public const string GetUserSepetList = "/api/malzemekart/GetUserSepetList";
        public const string PostSepet = "/api/malzemekart/PostSepet";
        public const string GetUserSepetCount = "/api/malzemekart/GetUserSepetCount";
        public const string GetSepetUrunList = "/api/malzemekart/GetSepetUrunList";
        public const string DeleteUserSepet = "/api/malzemekart/DeleteUserSepet";
        public const string DeleteSepetUrun = "/api/malzemekart/DeleteSepetUrun";

        public const string DovizListesi = "/api/doviz/GetDovizList";
        public const string DovizKuruGetir = "/api/doviz/GetDovizKur";

        public const string FileUpload = "/api/FileUpload/upload";
        public const string FileUpload2 = "/api/FileUpload/upload2";
        public const string FileUploadSingle = "/api/FileUpload/single";
        public const string FileSave = "/api/FileUpload/save";
        public const string FileGetList = "/api/FileUpload/list";
        public const string FileDelete = "/api/FileUpload/delete";

        public const string ProjeDetayRaporu = "/api/Rapor/ProjeDetayRaporu";
    }
}
