using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using Dapper;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Server.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class RefGeneratorService : IRefGenerator
    {
        public IConfiguration Configuration { get; }

        public RefGeneratorService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> GenerateRowRef(string table, string keyField, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                var result = await db.QueryFirstAsync<string>("select dbo.GenerateNewCode(isnull((select max(" +
                                    keyField
                                    + ") from " + table + "),'00000')) as value"
                                    , commandType: CommandType.Text);
                                                return result;
            }


        }

        public async Task<int> RefNoAl(string tablename, string firmaId)
        {

            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetPrizmeDbConnection()))
            {
                var p = new DynamicParameters();
                p.Add("@tablename", tablename);
                p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await db.ExecuteAsync("RefNoAl", p, commandType: CommandType.StoredProcedure);

                int c = p.Get<int>("@ReturnValue");

                return c;

            }

        }
        public async Task<IEnumerable<OdemePlaniDto>> GetOdemePlaniList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {

                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF,  CODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_PAYPLANS] with(nolock) where ACTIVE=0";

                IEnumerable<OdemePlaniDto> dbResponse;
                dbResponse = await db.QueryAsync<OdemePlaniDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }


        }
        public async Task<IEnumerable<SisSabitlerDetayDto>> GetSabitDetayList(int tip)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string sqlstring = string.Format("SELECT [sabit_detay_id] as SabitDetayId,[tip],[kodu],[ikodu],[adi],[yabanci_adi],[siralama],[ozel_kod1],[ozel_kod2],[ozel_kod3],[ozel_kod4],[ozel_kod5],[ozel_kod6],[ozel_kod7],[ozel_kod8],[ozel_kod9],[ozel_kod10],[ozel_kod11],[ozel_kod12],[izin],[renk1],[renk2] FROM [dbo].[sis_sabitler_detay] where tip = {0}", tip);
                IEnumerable<SisSabitlerDetayDto> dbResponse;
                dbResponse = await db.QueryAsync<SisSabitlerDetayDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }


        }
        public async Task<IEnumerable<SpeCodesDto>> GetCariSektorList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF,  SPECODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_SPECODES] with(nolock) where CODETYPE = 1 AND SPECODETYPE = 26 AND SPETYP3 = 1";

                IEnumerable<SpeCodesDto> dbResponse;
                dbResponse = await db.QueryAsync<SpeCodesDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }
        }
        public async Task<string> FisNoAlLogo(string table, string keyField, int firmaId, int logofirmaId)
        {
            if (firmaId < 1)
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId.ToString())))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmaId.ToString("000");
                string tblName = LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_"+ table + "]";

                var result = await db.QueryFirstAsync<string>("select dbo.GenerateNewCode(isnull((select max(" +
                                    keyField
                                    + ") from " + tblName + "),'00000')) as value"
                                    , commandType: CommandType.Text);
                return result;
            }


        }
        public async Task<IEnumerable<string>> GetTeslimSekliList()
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string sqlstring = "SELECT SDEF from " + LogoDbName + ".[dbo].L_SHPTYPES with(nolock) order by SDEF";

                IEnumerable<string> dbResponse;
                dbResponse = await db.QueryAsync<string>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }
        }
    }
}
