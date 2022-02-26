using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifService : ITeklifService
    {
        public IMapper Mapper { get; }
        public UmotaCompanyDbContext Db { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public TeklifService(IMapper mapper, UmotaCompanyDbContext db, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Db = db;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<TeklifDto> GetTeklifByRef(int logref)
        {
            return await Db.Teklifs.Where(i => i.Logref == logref)
                 .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<List<TeklifDto>> GetTeklifDtos(string firmaId)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                db.Open();

                var sql = "select top 100 * from " + Configuration.GetUmotaObjectName("teklif",firmaId:firmaId) + " order by insdate desc";

                var result = await db.QueryAsync<TeklifDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

            }

        }

        public async Task<TeklifDto> SaveTeklif(TeklifSaveRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());

            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklif = Mapper.Map<Teklif>(request.Teklif);
                await dbContext.Teklifs.AddAsync(teklif);
                await dbContext.SaveChangesAsync();
                return Mapper.Map<TeklifDto>(teklif);
            }


        }

        public async Task<List<TeklifDto>> SearchTeklif(TeklifDto teklif)
        {
            
            var word = teklif.Aciklama1.ToLower();

            return await Db.Teklifs.Where(x => x.Aciklama1.ToLower().Contains(word)
            || x.Aciklama2.ToLower().Contains(word)
            || x.Aciklama3.ToLower().Contains(word)
            || x.Aciklama3.ToLower().Contains(word)
            || x.Aciklama4.ToLower().Contains(word)
            || x.Teklifno.ToLower().Contains(word)
            || x.Tbelgeno.ToLower().Contains(word)
            || x.Lpersoneladi.ToLower().Contains(word)
            || x.LcariAdi.ToLower().Contains(word)
            || x.LcariKodu.ToLower().Contains(word))
                .OrderByDescending(x => x.Tarih)
                .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<TeklifDto> UpdateTeklif(TeklifDto teklifDto)
        {
            var teklifRow = await Db.Teklifs.Where(x => x.Logref == teklifDto.Logref).SingleOrDefaultAsync();
            if (teklifRow == null)
                throw new ApiException("Teklif Detayı bulunamadı");

            Mapper.Map(teklifDto, teklifRow);
            await Db.SaveChangesAsync();

            return Mapper.Map<TeklifDto>(teklifRow);
        }
    }
}
