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

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class MalzemeKartService : IMalzemeKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public MalzemeKartService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
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

            var word = request.MalzemeKart.Adi.ToLower();

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.V002Malzemelers.Where(x => x.Adi.ToLower().Contains(word)
                || x.Kodu.ToLower().Contains(word)
                || x.Adi3.ToLower().Contains(word)
                || x.Grupkodu.ToLower().Contains(word)
                || x.Ozelkod.ToLower().Contains(word)
                || x.Ozelkod2.ToLower().Contains(word)
                || x.Ozelkod3.ToLower().Contains(word))
                    .ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).ToListAsync();
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
    }
}
