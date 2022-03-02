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

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
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

        public async Task<IEnumerable<DovizDto>> GetDovizList(int logofirmno)
        {

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF, FIRMNR , CURTYPE, CURCODE , CURNAME from " + LogoDbName + ".[dbo].[L_CURRENCYLIST] with(nolock) WHERE CURTYPE IN(0,1,20,160,17,53) and FIRMNR = " + LogoFirmaNo + " order by CURCODE";

                IEnumerable<DovizDto> dbResponse;
                dbResponse = await db.QueryAsync<DovizDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;

            }

        }

        public async Task<double> LogoDovKurAl(int logofirmno, int dovizturu, int kurturu, DateTime kurtarihi)
        {
            double dovkur = 0;

            // TL döviz türlerinde kur tablosuna bakmaya gerek yok
            if (dovizturu == 160 || dovizturu == 53)
            {
                dovkur = 1;
            }
            else
            {
                using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
                {
                    string LogoDbName = Configuration["LogoDbName"];
                    string LogoFirmaNo = logofirmno.ToString("000");
                    string LogoTableName = "LG_EXCHANGE_" + LogoFirmaNo;
                    string FieldName = "RATES" + kurturu.ToString();
                    string sqlstring = "SELECT TOP 1 " + FieldName + " from " + LogoDbName + ".[dbo]." + LogoTableName + " with(nolock) WHERE CRTYPE = " + dovizturu + " AND EDATE <= :EDATE order by EDATE DESC";

                    var p = new DynamicParameters();
                    p.Add("@EDATE", value: kurtarihi, dbType: DbType.DateTime);

                    dovkur = await db.QueryFirstAsync<double>(sqlstring, p, commandType: CommandType.Text);
                }
            }

            return dovkur;
        }

        public async Task<IEnumerable<SisSabitlerDetayDto>> GetSabitDetayList(int tip)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string sqlstring = string.Format("SELECT [sabit_detay_id],[tip],[kodu],[ikodu],[adi],[yabanci_adi],[siralama],[ozel_kod1],[ozel_kod2],[ozel_kod3],[ozel_kod4],[ozel_kod5],[ozel_kod6],[ozel_kod7],[ozel_kod8],[ozel_kod9],[ozel_kod10],[ozel_kod11],[ozel_kod12],[izin],[renk1],[renk2] FROM [dbo].[sis_sabitler_detay] where tip = {0}", tip);
                IEnumerable<SisSabitlerDetayDto> dbResponse;
                dbResponse = await db.QueryAsync<SisSabitlerDetayDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }


        }

    }
}
