using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;


namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class MalzemeKartService : IMalzemeKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public MalzemeKartService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<List<UrunDto>> GetMalzemeKarts(string firmaId)
        {
            //if (string.IsNullOrEmpty(firmaId))
            //    throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                string Urun = Configuration.GetUmotaObjectName("Urun");
                string UrunFoto = Configuration.GetUmotaObjectName("UrunFoto");

                string sql = $@"select 
                                 A.ID, A.Kodu, A.Adi, A.Baslik, A.Ozellik, A.GrupKodu, A.HesaplananAdet
                                ,A.Fiyat1, A.Fiyat2, A.Fiyat3, A.HesaplananAdet, A.Sezon, A.AktarimGrup, A.Aktif

                                ,(Select top 1 imagePath from {UrunFoto} AA Where AA.UrunID = A.ID ORDER BY AnaFoto DESC, SiraNo ASC, ID ASC ) As imagePath

                                ,row_number() OVER (ORDER BY A.ID) SiraNo

                                from {Urun} A with(nolock)
                                where isDelete = 0";

                var result = await db.QueryAsync<UrunDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }

        public async Task<UrunDto> GetMalzemeKart(int logref, string firmaId)
        {
            //if (string.IsNullOrEmpty(firmaId))
            //    throw new Exception("Firma Dönem seçimi yapınız");


            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                string Urun = Configuration.GetUmotaObjectName("Urun");
                string UrunFoto = Configuration.GetUmotaObjectName("UrunFoto");

                string sql = $@"select 
                                 A.ID, A.Kodu, A.Adi, A.Baslik, A.Ozellik, A.GrupKodu
                                ,A.Fiyat1, A.Fiyat2, A.Fiyat3, A.HesaplananAdet, A.Sezon, A.AktarimGrup, A.Aktif

                                ,(Select top 1 imagePath from {UrunFoto} AA Where AA.UrunID = A.ID ORDER BY AnaFoto DESC, SiraNo ASC, ID ASC ) As imagePath

                                from {Urun} A with(nolock)
                                where ID = {logref}";

                var result = await db.QueryAsync<UrunDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();
            }
        }
        public async Task<List<UrunDto>> SearchMalzemeKarts(MalzemeKartRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                string Urun = Configuration.GetUmotaObjectName("Urun");
                string UrunFoto = Configuration.GetUmotaObjectName("UrunFoto");

                string sql = $@"select 
                                 A.ID, A.Kodu, A.Adi, A.Baslik, A.Ozellik, A.GrupKodu
                                ,A.Fiyat1, A.Fiyat2, A.Fiyat3, A.HesaplananAdet, A.Sezon, A.AktarimGrup, A.Aktif

                                ,(Select top 1 imagePath from {UrunFoto} AA Where AA.UrunID = A.ID ORDER BY AnaFoto DESC, SiraNo ASC, ID ASC ) As imagePath

                                ,row_number() OVER (ORDER BY A.ID) SiraNo

                                from {Urun} A with(nolock)
                                where isDelete = 0
                                and (@SearchText is null or A.Kodu like '%'+@SearchText+'%' or A.Adi like '%'+@SearchText+'%'
                                    or A.Baslik like '%'+@SearchText+'%'
                                    or A.Ozellik like '%'+@SearchText+'%'
                                    )

                            ";

                var result = await db.QueryAsync<UrunDto>(sql, new { SearchText = request.SearchText });

                db.Close();

                return result.ToList();
            }
        }
        public async Task<MalzemeKartDto> SaveMalzemeKart(MalzemeKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var malzKart = Mapper.Map<MalzKart>(request.MalzemeKart);

                await dbContext.MalzKarts.AddAsync(malzKart);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<MalzemeKartDto>(malzKart);
            }
        }
        public async Task<MalzemeKartDto> UpdateMalzemeKart(MalzemeKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var malzKart = await dbContext.MalzKarts.Where(x => x.Logref == request.MalzemeKart.Logref).SingleOrDefaultAsync();
                if (malzKart == null)
                    throw new Exception("Kart bulunamadı");

                // log dosyası
                var malzKartLog = new MalzKartLog();
                Mapper.Map(malzKart, malzKartLog);
                await dbContext.MalzKartLogs.AddAsync(malzKartLog);

                Mapper.Map(request.MalzemeKart, malzKart);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<MalzemeKartDto>(malzKart);
            }
        }

        public async Task<List<string>> GetFotoList(int urunId)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string UrunFoto = Configuration.GetUmotaObjectName("UrunFoto");

                var sql = $@"SELECT imagePath
                FROM {UrunFoto} 
                Where UrunID = {urunId}
                ORDER BY AnaFoto DESC, SiraNo ASC, ID ASC";

                var dbResponse = await db.QueryAsync<string>(sql, commandType: CommandType.Text);
                return dbResponse.ToList();

            }
        }
        public async Task<List<SepetDto>> GetUserSepetList(string kullaniciKodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                var sql = @"
                            SELECT 
                                SepetAdi,
                                COUNT(DISTINCT UrunID) AS UrunSayisi,
                                SUM(Miktar * Fiyat) AS ToplamTutar,
                                SUM(Miktar * FiyatTL) AS ToplamTutarTL
                            FROM [dbo].[UrunSepet]
                            WHERE InsUser = @User
                            GROUP BY SepetAdi
                            ORDER BY MAX(InsDate) DESC";

                var dbResponse = await db.QueryAsync<SepetDto>(sql, new { User = kullaniciKodu });
                return dbResponse.ToList();
            }
        }
        public async Task<List<SepetUrunDto>> GetSepetUrunList(string kullaniciKodu, string sepetAdi)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                var sql = @"
                            SELECT 
                            us.ID,
                            us.UrunID,
                            u.Kodu AS UrunKodu,
                            u.Adi AS UrunAdi,
                            u.Baslik AS UrunBaslik,
                            (Select top 1 imagePath from [dbo].[UrunFoto] Where UrunID = u.ID ORDER BY AnaFoto DESC, SiraNo ASC, ID ASC ) AS Foto,
                            us.Miktar, us.HesaplananAdet,
                            us.Fiyat, us.FiyatTL
                            FROM [dbo].[UrunSepet] us
                            INNER JOIN [dbo].[Urun] u ON u.ID = us.UrunID
                            WHERE us.InsUser = @User AND us.SepetAdi = @SepetAdi";

                var dbResponse = await db.QueryAsync<SepetUrunDto>(sql, new { User = kullaniciKodu, SepetAdi = sepetAdi });
                return dbResponse.ToList();
            }
        }
        public async Task<int> GetUserSepetCount(string kullaniciKodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string UrunSepet = Configuration.GetUmotaObjectName("UrunSepet");

                var sql = $@"SELECT Count(*) Say
                FROM {UrunSepet} 
                Where InsUser = '{kullaniciKodu}' ";

                int say = await db.QueryFirstOrDefaultAsync<int>(sql, commandType: CommandType.Text);
                return say;
            }
        }

        public async Task<int> SepetPost(SepetPostDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string UrunSepet = Configuration.GetUmotaObjectName("UrunSepet");

                string sql = "IF EXISTS (SELECT 1 FROM [dbo].[UrunSepet] WHERE InsUser=@InsUser AND SepetAdi=@SepetAdi AND UrunID=@UrunID) " +
                             "UPDATE [dbo].[UrunSepet] SET Miktar = @Miktar WHERE InsUser=@InsUser AND SepetAdi=@SepetAdi AND UrunID=@UrunID " +
                             "ELSE BEGIN " +
                             "Declare @Fiyat float = (Select top 1 Fiyat2 from [dbo].[Urun] where ID = @UrunID) " +
                             "Declare @FiyatTL float = (Select top 1 Fiyat3 from [dbo].[Urun] where ID = @UrunID) " +
                             "Declare @HesaplananAdet int = (Select top 1 HesaplananAdet from [dbo].[Urun] where ID = @UrunID) " +
                             "INSERT INTO [dbo].[UrunSepet] (InsUser, SepetAdi, UrunID, Miktar, Fiyat, FiyatTL, HesaplananAdet, InsDate) VALUES(@InsUser, @SepetAdi, @UrunID, @Miktar, @Fiyat, @FiyatTL, @HesaplananAdet, GetDate()) " +
                              "END";

                var p = new DynamicParameters();
                p.Add("@InsUser", request.KullaniciKodu);
                p.Add("@SepetAdi", request.SepetAdi);
                p.Add("@UrunID", request.UrunID);
                p.Add("@Miktar", request.Miktar);

                try
                {
                    await db.ExecuteAsync(sql, p, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw new ApiException(ex.Message);
                }
            }

            return 1;
        }

        public async Task<int> DeleteUserSepet(string kullaniciKodu, string sepetAdi)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                var sql = @"DELETE FROM [dbo].[UrunSepet] 
                            WHERE InsUser = @User AND SepetAdi = @SepetAdi";

                try
                {
                    await db.ExecuteAsync(sql, new { User = kullaniciKodu, SepetAdi = sepetAdi });
                }
                catch (Exception ex)
                {
                    throw new ApiException(ex.Message);
                }
            }

            return 1;
        }

        public async Task<int> DeleteSepetUrun(int urunId)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                var sql = @"DELETE FROM [dbo].[UrunSepet] 
                            WHERE ID = @ID";

                try
                {
                    await db.ExecuteAsync(sql, new { ID = urunId });
                }
                catch (Exception ex)
                {
                    throw new ApiException(ex.Message);
                }
            }

            return 1;
        }
        public async Task<int> ExceldenUrunleriAktar(string excelFileName, string kullaniciKodu)
        {

            // Önce bu excel dosyasından eski aktarım varsa ürünleri disable ediyoruz
            await DisableUrunAktarimGrup(excelFileName, kullaniciKodu);

            ExcelPackage.License.SetNonCommercialPersonal("MyNameisUmota");

            var excelFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dosyalar", excelFileName);
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/Products");

            try
            {
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 4; row <= worksheet.Dimension.End.Row; row++)
                {
                    var urunKoduCell = worksheet.Cells[row, 5];
                    string urunKodu = urunKoduCell?.Text?.Trim();

                    if (string.IsNullOrWhiteSpace(urunKodu) || urunKodu == "0")
                        continue;

                    var urun = new UrunDto
                    {
                        InsUser = kullaniciKodu,
                        Kodu = urunKodu,
                        Sezon = worksheet.Cells[row, 2].Text,
                        GrupKodu = worksheet.Cells[row, 3].Text,
                        Adi = worksheet.Cells[row, 4].Text,
                        Baslik = worksheet.Cells[row, 7].Text,
                        Ozellik = worksheet.Cells[row, 8].Text,
                        AktarimGrup = excelFileName,
                        Aktif = 0
                    };

                    string adet = worksheet.Cells[row, 9].Text.Replace(".", "").Trim();
                    urun.HesaplananAdet = int.TryParse(adet, out int val) ? val : 0;

                    urun.Fiyat1 = 0;// double.TryParse(worksheet.Cells[row, 9].Text, out double f1) ? f1 : 0;
                    urun.Fiyat2 = double.TryParse(worksheet.Cells[row, 10].Text, out double f2) ? f2 : 0;
                    urun.Fiyat3 = double.TryParse(worksheet.Cells[row, 11].Text, out double f3) ? f3 : 0;


                    // Veritabanına ürün kaydı
                    int urunId = await KaydetUrun(urun);
                    
                    // Varsa önceki fotoğrafları sil

                    string searchPattern = $"{urun.Kodu.Replace("/", "_")}_*.png";
                    // klasördeki dosyaları bul
                    var files = Directory.GetFiles(uploadFolder, searchPattern, SearchOption.TopDirectoryOnly);

                    foreach (var file in files)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Dosya silinemedi: {file} - Hata: {ex.Message}");
                        }
                    }

                    await SilUrunFotograf(urunId);
                    // -------------------------------

                    int imageNum = 0;

                    foreach (var drawing in worksheet.Drawings)
                    {
                        var picture = drawing as OfficeOpenXml.Drawing.ExcelPicture;
                        if (picture != null && picture.From.Row + 1 == row) // ilgili satırdaki resim
                        {
                            imageNum++;
                            // Benzersiz dosya adı oluştur
                            //string fileName = Guid.NewGuid().ToString() + ".png";
                            string fileName = $"{urun.Kodu.Replace("/", "_")}_{Guid.NewGuid().ToString()}.png";
                            string fullPath = Path.Combine(uploadFolder, fileName);

                            // Resmi kaydet
                            File.WriteAllBytes(fullPath, picture.Image.ImageBytes);

                            string imagePath = "/Uploads/Products/" + fileName;

                            await KaydetUrunFotograf(urunId, imageNum, imagePath, urun.InsUser);
                        }
                    }

                }
            }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return 1;
        }

        private async Task<int> KaydetUrun(UrunDto urun)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                var p = new DynamicParameters();
                p.Add("@Kodu", urun.Kodu);
                p.Add("@Adi", urun.Adi);
                p.Add("@Baslik", urun.Baslik);
                p.Add("@Ozellik", urun.Ozellik);
                p.Add("@GrupKodu", urun.GrupKodu.Trim());
                p.Add("@Fiyat1", urun.Fiyat1);
                p.Add("@Fiyat2", urun.Fiyat2);
                p.Add("@Fiyat3", urun.Fiyat3);
                p.Add("@HesaplananAdet", urun.HesaplananAdet);
                p.Add("@Sezon", urun.Sezon);
                p.Add("@AktarimGrup", urun.AktarimGrup);
                p.Add("@Aktif", urun.Aktif);
                p.Add("@KullaniciKodu", urun.InsUser);


                int say = await db.ExecuteScalarAsync<int>("spInsertOrUpdateUrun", p, commandType: CommandType.StoredProcedure);
                return say;
            }
        }

        private async Task KaydetUrunFotograf(int urunId, int sirano, string resimYolu, string kullanici_kodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                //string sql = "IF NOT EXISTS (SELECT TOP 1 ID FROM [dbo].[UrunFoto] WHERE UrunID = @urunId and SiraNo = @sirano and isDelete = 0) INSERT INTO [dbo].[UrunFoto] (UrunID, SiraNo, imagePath, isDelete, InsUser, InsDate) VALUES (@urunId, @sirano, @resim, 0, @InsUser, GetDate())";
                string sql = "INSERT INTO [dbo].[UrunFoto] (UrunID, SiraNo, imagePath, isDelete, InsUser, InsDate) VALUES (@urunId, @sirano, @resim, 0, @InsUser, GetDate())";

                var p = new DynamicParameters();
                p.Add("@urunId", urunId);
                p.Add("@sirano", sirano);
                p.Add("@resim", resimYolu);
                p.Add("@InsUser", kullanici_kodu);

                await db.ExecuteScalarAsync(sql, p, commandType: CommandType.Text);
            }
        }

        private async Task SilUrunFotograf(int urunId)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string sql = "Delete FROM [dbo].[UrunFoto] WHERE UrunID = @urunId";

                var p = new DynamicParameters();
                p.Add("@urunId", urunId);

                await db.ExecuteScalarAsync(sql, p, commandType: CommandType.Text);
            }
        }

        private async Task DisableUrunAktarimGrup(string aktarimGrup, string kullanici_kodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string sql = "Update [dbo].[Urun] Set Aktif = 1, UpdDate = GetDate(), UpdUser = @UpdUser  Where AktarimGrup = @AktarimGrup and Aktif = 0";

                var p = new DynamicParameters();
                p.Add("@AktarimGrup", aktarimGrup);
                p.Add("@UpdUser", kullanici_kodu);

                await db.ExecuteScalarAsync(sql, p, commandType: CommandType.Text);
            }
        }


    }
}
