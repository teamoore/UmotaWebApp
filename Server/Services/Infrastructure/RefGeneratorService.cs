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

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class RefGeneratorService : IRefGenerator
    {
        private readonly DbConnection _sql;

        public RefGeneratorService(DbConnection sql)
        {
            _sql = sql;
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
    }
}
