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

            using (SqlConnection db = new(Configuration.GetUmotaConnectionString(firmaId)))
            {
                var sql = @"select top 10 temsilciadi as PersonelAdi, sum([tutarmatrahtl]) as MatrahTutar
                              from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId: firmaId) + " with(nolock)" +
                " where temsilciadi is not null and revizyon = 0 and duruminfo = '" + Shared.SharedConsts.TeklifDurum.KesinSipLogoyaAktarildi + "'";
                if (year != null)
                    sql += " and year(tarih) = " + year.ToString();

                sql += " group by temsilciadi  order by MatrahTutar desc";

                var result = await db.QueryAsync<PersonelTeklifSatisDto>(sql, commandType: CommandType.Text);

                return result;
            }
        }
    }
}
