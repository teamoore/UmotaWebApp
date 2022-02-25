using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class SisFirmaDonemService : ISisFirmaDonemService
    {
        private readonly DbConnection _sql;
        public IConfiguration Configuration { get; }

        public SisFirmaDonemService(DbConnection sql, IConfiguration configuration)
        {
            _sql = sql;
            Configuration = configuration;
        }

        public async Task<List<SisFirmaDonemDto>> GetSisFirmaDonem(string kullanici)
        {

            using (SqlConnection db = new SqlConnection(Configuration.GetConnectionString("masterDb")))
            {
                db.Open();
                
                var p = new DynamicParameters();
                p.Add("@kullanici_kodu", kullanici);

                var result = await db.QueryAsync<SisFirmaDonemDto>("GetKullaniciFirmaDonemYetkisiByKullaniciKodu", p, commandType: CommandType.StoredProcedure);

                db.Close();

                return result.ToList();

            }


        }
    }
}
