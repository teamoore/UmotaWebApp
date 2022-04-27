using AutoMapper;
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

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class ReportService : ITeklifReportService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public ReportService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<int> KacAdetMusteriOnayiBekliyorTeklifVar(string firmaId, string kullanici)
        {
            using (SqlConnection db = new (Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select count(1) as cnt from " +
                   Configuration.GetUmotaObjectName("v009_teklif", firmaId: firmaId) + " a with(nolock) where a.duruminfo = '" + Shared.SharedConsts.TeklifDurum.MusteriOnayiBekliyor + "'";

                sql += " and [insuser] = '" + kullanici + "' and revizyon = 0";

                var result = await db.ExecuteScalarAsync<int>(sql, commandType: CommandType.Text);

                db.Close();

                return result;

            }
        }
        public async Task<List<CariDurumRaporuDto>> CariDurumRaporu(CariDurumRaporuRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);
                p.Add("@BaslangicCariKodu", request.BaslangicCariKodu);
                p.Add("@BitisCariKodu", request.BitisCariKodu);
                p.Add("@BakiyeSecimi", request.BakiyeSecimi);
                p.Add("@RaporTarihi", request.RaporTarihi);
                p.Add("@SearchText", request.SearchText);

                var res = await db.QueryAsync<CariDurumRaporuDto>("UmotaRaporSP_CariDurum", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }

    }
}
