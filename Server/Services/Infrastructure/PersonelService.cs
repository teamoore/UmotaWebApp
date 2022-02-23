using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class PersonelService : IPersonelService
    {
        private readonly DbConnection _sql;

        public PersonelService(DbConnection sql)
        {
            _sql = sql;
        }

        public async Task<IEnumerable<PersonelDto>> GetPersonelList()
        {
            IEnumerable<PersonelDto> dbResponse;
            dbResponse = await _sql.QueryAsync<PersonelDto>("SELECT  LOGICALREF,  CODE,  DEFINITION_ from [dbo].[LV_SLSMAN]", commandType: CommandType.Text);
            return dbResponse;
        }
    }
}
