using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using System.Data.Common;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class MalzemeKartService : IMalzemeKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public MalzemeKartService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<MalzemeKartDto> GetMalzemeKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.V002Malzemelers.Where(i => i.Logref == logref)
                        .ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
            }
        }
        public async Task<List<MalzemeKartDto>> SearchMalzemeKart(MalzemeKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            string word = request.MalzemeKart.Adi != null ? request.MalzemeKart.Adi.ToLower() : null;
            string marka = request.MalzemeKart.Marka != null ? request.MalzemeKart.Marka.ToLower() : null;

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.V002Malzemelers.Where(x => (x.Active == 0)
                && (word == null || x.Adi.ToLower().Contains(word) || x.Kodu.ToLower().Contains(word))
                && (marka == null || x.Descr.Contains(marka))
                    ).ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).ToListAsync();
            }
        }
        public async Task<MalzemeFiyatDto>MalzemeFiyatGetir(MalzemeFiyatRequestDto request)
        {
            MalzemeFiyatDto res = new MalzemeFiyatDto();

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = request.LogoFirmaNo.ToString("000");
                string TblPRCLIST = "LG_" + LogoFirmaNo + "_PRCLIST";
                string TblUNITSETL = "LG_" + LogoFirmaNo + "_UNITSETL";
                string TblCURRENCYLIST = "L_CURRENCYLIST";

                string sqlstring = "SELECT TOP 1 A.CARDREF MalzemeRef, A.PRICE Fiyat, A.CURRENCY DovizRef, B.CURCODE DovizKodu" +
                    ", C.LOGICALREF FiyatBirimRef, C.CODE FiyatBirimKodu, C.UNITSETREF FiyatBirimSetiRef, A.INCVAT KdvDahil" +
                    " from " + LogoDbName + ".[dbo]." + TblPRCLIST + " A with(nolock) " +
                    " left join " + LogoDbName + ".[dbo]." + TblCURRENCYLIST + " B WITH(NOLOCK) ON A.CURRENCY = B.CURTYPE AND B.FIRMNR = " + request.LogoFirmaNo +
                    " left join " + LogoDbName + ".[dbo]." + TblUNITSETL + " C WITH(NOLOCK) ON  A.UOMREF = C.LOGICALREF" +

                " WHERE A.PTYPE = 2 AND A.ACTIVE = 0" +
                    " AND A.CARDREF = " + request.MalzemeRef +
                    " AND C.CODE = '" + request.BirimKodu + "'" +
                    " AND @TARIH BETWEEN A.BEGDATE AND A.ENDDATE ";

                // Cari ve Para Birime Göre
                string sqlstring2 = " AND A.CLIENTCODE = '" + request.CariKodu + "'" +
                    " AND A.CURRENCY = " + request.DovizRef +
                    " order by A.LOGICALREF DESC";

                var p = new DynamicParameters();
                p.Add("@TARIH", value: request.Tarih, dbType: DbType.DateTime);

                res = await db.QuerySingleOrDefaultAsync<MalzemeFiyatDto>(sqlstring+ sqlstring2, p, commandType: CommandType.Text);

                // Bulamazsa Cari ve Tüm Para Birime Göre
                if (res == null)
                {
                    sqlstring2 = " AND A.CLIENTCODE = '" + request.CariKodu + "'" +
                        " order by A.LOGICALREF DESC";

                    res = await db.QuerySingleOrDefaultAsync<MalzemeFiyatDto>(sqlstring + sqlstring2, p, commandType: CommandType.Text);

                }
                // Bulamazsa Carisiz ve Para Birime Göre
                if (res == null)
                {
                    sqlstring2 = " AND A.CURRENCY = " + request.DovizRef +
                        " order by A.CLIENTCODE ASC, A.LOGICALREF DESC";

                    res = await db.QuerySingleOrDefaultAsync<MalzemeFiyatDto>(sqlstring + sqlstring2, p, commandType: CommandType.Text);
                }

                // Bulamazsa Carisiz ve Tüm Para Birime Göre
                if (res == null)
                {
                    sqlstring2 = " order by A.CLIENTCODE ASC, A.LOGICALREF DESC";

                    res = await db.QuerySingleOrDefaultAsync<MalzemeFiyatDto>(sqlstring + sqlstring2, p, commandType: CommandType.Text);
                }
            }

            return res;
        }
        public async Task<MalzemeFiyatDto> MalzemeMaliyetGetir(MalzemeFiyatRequestDto request)
        {
            MalzemeFiyatDto res = new MalzemeFiyatDto();

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = request.LogoFirmaNo.ToString("000");
                string TblPRCLIST = "LG_" + LogoFirmaNo + "_PRCLIST";
                string TblUNITSETL = "LG_" + LogoFirmaNo + "_UNITSETL";
                string TblCURRENCYLIST = "L_CURRENCYLIST";

                string sqlstring = "SELECT TOP 1 A.CARDREF MalzemeRef, A.PRICE Fiyat, A.CURRENCY DovizRef, B.CURCODE DovizKodu" +
                    ", C.LOGICALREF FiyatBirimRef, C.CODE FiyatBirimKodu, C.UNITSETREF FiyatBirimSetiRef, A.INCVAT KdvDahil" +
                    ", (case when  ISNUMERIC(A.DEFINITION_) = 1 then A.PRICE * A.DEFINITION_ else A.PRICE END) OzelFiyat" +
                    " from " + LogoDbName + ".[dbo]." + TblPRCLIST + " A with(nolock) " +
                    " left join " + LogoDbName + ".[dbo]." + TblCURRENCYLIST + " B WITH(NOLOCK) ON A.CURRENCY = B.CURTYPE AND B.FIRMNR = " + request.LogoFirmaNo +
                    " left join " + LogoDbName + ".[dbo]." + TblUNITSETL + " C WITH(NOLOCK) ON  A.UOMREF = C.LOGICALREF" +
                     
                " WHERE A.PTYPE = 1 AND A.ACTIVE = 0" +
                    " AND A.CARDREF = " + request.MalzemeRef +
                    " AND C.CODE = '" + request.BirimKodu + "'" +
                    " AND @TARIH BETWEEN A.BEGDATE AND A.ENDDATE " +
                    " AND A.CURRENCY = " + request.DovizRef +
                    " order by A.CLIENTCODE";

                var p = new DynamicParameters();
                p.Add("@TARIH", value: request.Tarih, dbType: DbType.DateTime);

                res = await db.QuerySingleOrDefaultAsync<MalzemeFiyatDto>(sqlstring, p, commandType: CommandType.Text);
            }

            return res;
        }
        public async Task<List<MalzemeStokDto>> SearchMalzemeKartStoklu(MalzemeStokRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@LogoFirmaNo", request.LogoFirmaNo);
                p.Add("@LogoDonemNo", request.LogoDonemNo);
                p.Add("@SearchText", request.SearchText);
                p.Add("@MalzemeKodu", request.MalzemeKodu);
                p.Add("@MalzemeAdi", request.MalzemeAdi);
                p.Add("@MalzemeMarka", request.MalzemeMarka);
                p.Add("@TopRowCount", request.TopRowCount);
                p.Add("@Active", 0);
                p.Add("@UmotaFirmaNo", request.UmotaFirmaNo);
                p.Add("@UmotaKartlariGetir", request.UmotaKartlariGetir);

                var res = await db.QueryAsync<MalzemeStokDto>("GetMalzemeStokList", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
        public async Task<MalzemeKartDto> SaveMalzemeKart(MalzemeKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var malzKart = Mapper.Map<MalzKart>(request.MalzemeKart);

                await dbContext.MalzKarts.AddAsync(malzKart);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<MalzemeKartDto>(malzKart);
            }
        }
        public async Task<IEnumerable<MalzemeBirimSetDto>> GetMalzemeBirimSetList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT A.LOGICALREF BirimSetRef, A.CODE BirimSetKodu, B.LOGICALREF AnaBirimRef, B.CODE AnaBirimKodu from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_UNITSETF] A with(nolock) INNER JOIN " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_UNITSETL] B with(nolock) on (A.LOGICALREF = B.UNITSETREF AND B.MAINUNIT = 1)  where A.LOGICALREF > 4";

                IEnumerable<MalzemeBirimSetDto> dbResponse;
                dbResponse = await db.QueryAsync<MalzemeBirimSetDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }
        }
        public async Task<IEnumerable<SpeCodesDto>> GetMalzemeGrupList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF,  SPECODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_SPECODES] with(nolock) where CODETYPE = 4";

                IEnumerable<SpeCodesDto> dbResponse;
                dbResponse = await db.QueryAsync<SpeCodesDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }
        }
        public async Task<IEnumerable<SpeCodesDto>> GetMalzemeMarkaList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF,  CODE SPECODE,  DESCR DEFINITION_ from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_MARK] with(nolock)";

                IEnumerable<SpeCodesDto> dbResponse;
                dbResponse = await db.QueryAsync<SpeCodesDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }
        }
    }
}
