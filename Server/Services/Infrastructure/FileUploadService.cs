﻿using Dapper;
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

        public FileUploadService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<FileUploadDto> Upload(FileUploadRequestDto request,CancellationToken cancellationToken)
        {
            try
            {
                var dosyaAdi = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd-hhmmss"), request.UploadedFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dosyalar", dosyaAdi);

                using var stream = new FileStream(path, FileMode.Create);
                await request.UploadedFile.OpenReadStream().CopyToAsync(stream);

                request.File.FileName = dosyaAdi;

                using (SqlConnection db = new SqlConnection(Configuration.GetUmotaImageDbConnectionString(request.FirmaId.ToString())))
                {
                    db.Open();
                    var p = new DynamicParameters();

                    var sqlstmt = "insert into [dbo].[imagedata] (logref,tablename,tablelogref,ifilename,aciklama,insuser,insdate) " +
                        "values (@LogRef,@TableName,@TableLogRef,@FileName,@Aciklama,@InsUser,getdate())";
                    p.Add("@LogRef", request.File.LogRef, dbType: DbType.Int64);
                    p.Add("@TableName", request.File.TableName, dbType: DbType.String);
                    p.Add("@TableLogRef", request.File.TableLogRef, dbType: DbType.Int64);
                    p.Add("@FileName", request.File.FileName, dbType: DbType.String);
                    p.Add("@Aciklama", request.File.Aciklama, dbType: DbType.String);
                    p.Add("@InsUser", request.File.Insuser, dbType: DbType.String);

                    var result = await db.ExecuteAsync(sqlstmt, p, commandType: CommandType.Text);
                }

                request.File.IsSuccessed = true;

            }
            catch (Exception)
            {
                request.File.IsSuccessed = false;
            }

            return request.File;
        }
    }
}
