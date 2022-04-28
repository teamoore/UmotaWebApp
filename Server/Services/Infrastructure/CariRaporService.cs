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
    public class CariRaporService : ICariRaporService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public CariRaporService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
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
                p.Add("@CariAdi", request.CariAdi);

                var res = await db.QueryAsync<CariDurumRaporuDto>("UmotaRaporSP_CariDurum", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
        public async Task<List<CariHesapEkstresiDto>> CariHesapEkstresi(CariHesapEkstresiRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);
                p.Add("@CariKodu", request.CariKodu);
                p.Add("@BaslangicTarih", request.BaslangicTarih);
                p.Add("@BitisTarih", request.BitisTarih);

                var res = await db.QueryAsync<CariHesapEkstresiDto>("UmotaRaporSP_CariEkstre", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
    }
}
