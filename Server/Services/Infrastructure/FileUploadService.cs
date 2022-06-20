using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class FileUploadService : IFileUpload
    {
        public IConfiguration Configuration { get; }
        public IRefGenerator RefGeneratorService { get; }
        public FileUploadService(IConfiguration configuration, IRefGenerator refGeneratorService)
        {
            Configuration = configuration;
            RefGeneratorService = refGeneratorService;
            RefGeneratorService = refGeneratorService;
        }

        public async Task<FileUploadDto> Upload(IBrowserFile file, CancellationToken cancellationToken)
        {
            var dosyaAdi = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd-hhmmss"), file.Name);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dosyalar", dosyaAdi);

            var result = new FileUploadDto();
            
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(stream);
                var ms = new MemoryStream();
                stream.CopyTo(ms);

                result.FileName = dosyaAdi;
                result.Image = ms.ToArray();
                result.ImageFilePath = path;
                result.ImageType = file.ContentType;
            }

            return result;
        }

        public async Task<FileUploadDto> Upload(FileDataDto file)
        {
            var dosyaAdi = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd-hhmmss"), file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dosyalar", dosyaAdi);

            var result = new FileUploadDto();

            var fs = File.Create(path);
            await fs.WriteAsync(file.Data, 0, file.Data.Length);
            fs.Close();
            await fs.DisposeAsync();

            result.FileName = file.FileName;
            result.Image = file.Data;
            result.ImageFilePath = path;
            result.ImageType = file.FileType;

            return result;
        }

        public async Task<bool> Save(FileUploadRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaImageDbConnectionString(request.FirmaId.ToString())))
            {
                db.Open();
                var p = new DynamicParameters();

                request.File.LogRef = await RefGeneratorService.RefNoAl("imagedata", request.FirmaId.ToString());

                var sqlstmt = "insert into [dbo].[imagedata] (logref,tablename,tablelogref,ifilename,aciklama,insuser,insdate) " +
                    "values (@LogRef,@TableName,@TableLogRef,@FileName,@Aciklama,@InsUser,getdate())";

                p.Add("@LogRef", request.File.LogRef, dbType: DbType.Int64);
                p.Add("@TableName", request.File.TableName, dbType: DbType.String);
                p.Add("@TableLogRef", request.File.TableLogRef, dbType: DbType.Int64);
                p.Add("@FileName", request.File.FileName, dbType: DbType.String);
                p.Add("@Aciklama", request.File.Aciklama, dbType: DbType.String);
                p.Add("@InsUser", request.File.Insuser, dbType: DbType.String);
                p.Add("@Image", request.File.Image, dbType: DbType.Binary);

                var result = await db.ExecuteAsync(sqlstmt, p, commandType: CommandType.Text);

                return true;
            }

            
        }
    }
}
