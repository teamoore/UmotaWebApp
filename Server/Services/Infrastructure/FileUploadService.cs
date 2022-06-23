using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Contexts;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class FileUploadService : IFileUpload
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        public IRefGenerator RefGeneratorService { get; }
        public FileUploadService(IConfiguration configuration, IRefGenerator refGeneratorService, IMapper mapper)
        {
            Configuration = configuration;
            RefGeneratorService = refGeneratorService;
            RefGeneratorService = refGeneratorService;
            Mapper = mapper;
        }

        public async Task<FileUploadDto> Upload(IBrowserFile file, CancellationToken cancellationToken)
        {
            var dosyaAdi = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd-hhmmss"), file.Name);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dosyalar", dosyaAdi);

            var result = new FileUploadDto();
            
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var maxSize = 1024 * 1024 * 8; //8 Mb 
                await file.OpenReadStream(maxAllowedSize: maxSize).CopyToAsync(stream);
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

            result.FileName = dosyaAdi;
            result.Image = file.Data;
            result.ImageFilePath = path;
            result.ImageType = file.FileType;

            return result;
        }

        public async Task<ImageDataDto> Save(FileUploadRequestDto request)
        {
            request.ImageData = new ImageDataDto()
            {
                 FileName = request.File.FileName,
                 iData = request.File.Image,
                 iType = request.File.ImageType,
                 Logref = request.File.LogRef,
                 TableLogref = request.File.TableLogRef,
                 TableName = request.File.TableName,
                 Insdate = DateTime.Now,
                 Insuser = request.File.Insuser
            };

            
            var connectionstring = Configuration.GetUmotaImageDbConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaImageDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaImageDbContext dbContext = new (optionsBuilder.Options))
            {
                var imgdata = Mapper.Map<ImageData>(request.ImageData);
                await dbContext.ImageDatas.AddAsync(imgdata);

                await dbContext.SaveChangesAsync();
                return Mapper.Map<ImageDataDto>(imgdata);
            }

        }

        public async Task<List<ImageDataDto>> GetList(FileUploadRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaImageDbConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaImageDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaImageDbContext dbContext = new(optionsBuilder.Options))
            {
                return await dbContext.ImageDatas.Where(x => x.TableName == request.TableName && x.TableLogref == request.TableLogref)
                    .ProjectTo<ImageDataDto>(Mapper.ConfigurationProvider).ToListAsync();
            }
        }

        public async Task<bool> DeleteFile(FileUploadRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaImageDbConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaImageDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaImageDbContext dbContext = new(optionsBuilder.Options))
            {
                var img = await dbContext.ImageDatas.Where(x => x.Logref == request.File.LogRef).SingleOrDefaultAsync();

                if (img == null)
                    throw new Exception("Dosya bulunamadı");

                dbContext.ImageDatas.Remove(img);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
