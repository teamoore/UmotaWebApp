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
    public class DovizService : IDovizService
    {
        public IConfiguration Configuration { get; }

        public DovizService(IConfiguration configuration)
        {
            Configuration = configuration;
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
    }
}
