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

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class RefGeneratorService : IRefGenerator
    {
        private readonly DbConnection _sql;
        public IConfiguration Configuration { get; }

        public RefGeneratorService(DbConnection sql, IConfiguration configuration)
        {
            _sql = sql;
            Configuration = configuration;
        }

        public async Task<string> GenerateRowRef(string table, string keyField)
        {
            var result = await _sql.QueryFirstAsync<string>("select dbo.GenerateNewCode(isnull((select max("+
                keyField
                +") from " + table + "),'00000')) as value"
                , commandType: CommandType.Text); 
            return result;
        }

        public async Task<int> RefNoAl(string tablename)
        {
            var p = new DynamicParameters();
            p.Add("@tablename", tablename);
            //p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _sql.ExecuteAsync("RefNoAl", p, commandType: CommandType.StoredProcedure);

            //int b = p.Get<int>("@b");
            int c = p.Get<int>("@ReturnValue");

            return c;
        }
        public async Task<IEnumerable<OdemePlaniDto>> GetOdemePlaniList(int logofirmno)
        {
            string LogoDbName = Configuration["LogoDbName"];
            string LogoFirmaNo = logofirmno.ToString("000");
            string sqlstring = "SELECT  LOGICALREF,  CODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_" + LogoFirmaNo + "_PAYPLANS] with(nolock) where ACTIVE=0";

            IEnumerable<OdemePlaniDto> dbResponse;
            dbResponse = await _sql.QueryAsync<OdemePlaniDto>(sqlstring, commandType: CommandType.Text);
            return dbResponse;
        }

        public async Task<IEnumerable<DovizDto>> GetDovizList(int logofirmno)
        {
            string LogoDbName = Configuration["LogoDbName"];
            string LogoFirmaNo = logofirmno.ToString("000");
            string sqlstring = "SELECT  LOGICALREF, FIRMNR , CURTYPE, CURCODE , CURNAME from " + LogoDbName + ".[dbo].[L_CURRENCYLIST] with(nolock) WHERE CURTYPE IN(0,1,20,160,17,53) and FIRMNR = " + LogoFirmaNo + " order by CURCODE";

            IEnumerable<DovizDto> dbResponse;
            dbResponse = await _sql.QueryAsync<DovizDto>(sqlstring, commandType: CommandType.Text);
            return dbResponse;
        }

        public async Task<IEnumerable<SisSabitlerDetayDto>> GetSabitDetayList(int tip)
        {
            string sqlstring = string.Format("SELECT [sabit_detay_id],[tip],[kodu],[ikodu],[adi],[yabanci_adi],[siralama],[ozel_kod1],[ozel_kod2],[ozel_kod3],[ozel_kod4],[ozel_kod5],[ozel_kod6],[ozel_kod7],[ozel_kod8],[ozel_kod9],[ozel_kod10],[ozel_kod11],[ozel_kod12],[izin],[renk1],[renk2] FROM [UmotaUnoPazar].[dbo].[sis_sabitler_detay] where tip = {0}", tip);
            IEnumerable<SisSabitlerDetayDto> dbResponse;
            dbResponse = await _sql.QueryAsync<SisSabitlerDetayDto>(sqlstring, commandType: CommandType.Text);
            return dbResponse;
        }

    }
}
