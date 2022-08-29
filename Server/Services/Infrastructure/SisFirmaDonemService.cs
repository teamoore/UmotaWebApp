using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Server.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using UmotaWebApp.Shared.CustomException;
using Microsoft.EntityFrameworkCore;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class SisFirmaDonemService : ISisFirmaDonemService
    {
        public IConfiguration Configuration { get; }
        public UmotaMasterDbContext MasterDbContext { get; }
        public IMapper Mapper { get; }
        public SisFirmaDonemService(IMapper mapper, UmotaMasterDbContext masterDbContext, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
            MasterDbContext = masterDbContext;
        }

        public async Task<List<SisFirmaDonemDto>> GetSisFirmaDonem(string kullanici)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                db.Open();
                
                var p = new DynamicParameters();
                p.Add("@kullanici_kodu", kullanici);

                var sql = Configuration.GetUmotaObjectName("GetKullaniciFirmaDonemYetkisiByKullaniciKodu");
                
                var result = await db.QueryAsync<SisFirmaDonemDto>(sql,p, commandType: CommandType.StoredProcedure);

                db.Close();

                return result.OrderByDescending(x => x.ondeger).ThenByDescending(x => x.logref).ToList();
            }
        }
        public async Task<SisFirmaDonemDto> GetSisFirmaDonemOnDeger()
        {
            var firmadonem = await MasterDbContext.SisFirmaDonems.Where(x => x.Ondeger == 1)
                .ProjectTo<SisFirmaDonemDto>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (firmadonem == null)
                throw new ApiException("Öndeğer firma bulunamadı");

            return firmadonem;
        }
    }
}
