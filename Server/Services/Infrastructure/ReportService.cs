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
using UmotaWebApp.Shared.ModelDto.Request;

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
        public async Task<List<SiparisRaporuDto>> SiparisRaporu(SiparisRaporuRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);
                p.Add("@SipNo", request.SipNo);
                p.Add("@CariKodu", request.CariKodu);
                p.Add("@CariAdi", request.CariAdi);
                p.Add("@MalzemeKodu", request.MalzemeKodu);
                p.Add("@MalzemeAdi", request.MalzemeAdi);
                p.Add("@BaslangicTarih", request.BaslangicTarih);
                p.Add("@BitisTarih", request.BitisTarih);
                p.Add("@OnayDurum", request.OnayDurumu);
                p.Add("@SiparisTuru", request.SiparisTuru);
                p.Add("@SadeceBekleyenler", request.SadeceBekleyenler);
                p.Add("@BaslangicTeslimTarih", request.BaslangicTeslimTarih);
                p.Add("@BitisTeslimTarih", request.BitisTeslimTarih);

                var res = await db.QueryAsync<SiparisRaporuDto>("UmotaRaporSP_SiparisDurum", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
        public async Task<List<TahsilatRaporuDto>> TahsilatRaporu(TahsilatRaporuRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);
                p.Add("@CariKodu", request.CariKodu);
                p.Add("@BaslangicTarih", request.BaslangicTarih);
                p.Add("@BitisTarih", request.BitisTarih);

                var res = await db.QueryAsync<TahsilatRaporuDto>("UmotaRaporSP_TahsilatRaporu", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
        public async Task<List<BankaDurumRaporuDto>> BankaDurumRaporu(BankaDurumRaporuRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);

                var res = await db.QueryAsync<BankaDurumRaporuDto>("UmotaRaporSP_BankaDurumRaporu", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
    }
}
