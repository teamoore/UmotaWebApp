using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class DashboardInfo : IDashboardInfo
    {
        public IConfiguration Configuration { get; }
        public DashboardInfo(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<PersonelTeklifSatisDto>> GetPersonelTeklifSatis(string firmaId, int? year)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                var sql = @"  select top 10 lpersoneladi as PersonelAdi,sum([tutarmatrahtl]) as MatrahTutar
                              from [UmotaUnoPazar_001].[dbo].[v029_teklif]
                              where lpersoneladi is not null ";
                if (year != null)
                    sql += " and year(tarih) = " + year.ToString();

                sql += " group by lpersoneladi  order by MatrahTutar desc";

                var result = await db.QueryAsync<PersonelTeklifSatisDto>(sql, commandType: CommandType.Text);

                return result;
            }
        }
    }
}
