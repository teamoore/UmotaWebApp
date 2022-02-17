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
    }
}
