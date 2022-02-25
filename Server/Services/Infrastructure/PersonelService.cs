using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using Microsoft.Extensions.Configuration;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class PersonelService : IPersonelService
    {
        private readonly DbConnection _sql;
        public IConfiguration Configuration { get; }
        public PersonelService(DbConnection sql, IConfiguration configuration)
        {
            _sql = sql;
            Configuration = configuration;
        }

        public async Task<IEnumerable<PersonelDto>> GetPersonelList(int logofirmno)
        {
            string LogoDbName = Configuration["LogoDbName"];
            string LogoFirmaNo = logofirmno.ToString("000");
            string sqlstring = "SELECT  LOGICALREF,  CODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_SLSMAN] with(nolock) WHERE ACTIVE=0 and (FIRMNR = -1 OR FIRMNR = " + LogoFirmaNo + ")";

            IEnumerable<PersonelDto> dbResponse;
            dbResponse = await _sql.QueryAsync<PersonelDto>("SELECT  LOGICALREF,  CODE,  DEFINITION_ from [dbo].[LV_SLSMAN]", commandType: CommandType.Text);
            return dbResponse;
        }
    }
}
