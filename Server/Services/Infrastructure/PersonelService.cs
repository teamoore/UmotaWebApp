using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using UmotaWebApp.Server.Extensions;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class PersonelService : IPersonelService
    {
        public IConfiguration Configuration { get; }
        public PersonelService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<PersonelDto>> GetPersonelList(int logofirmno)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(null)))
            {
                string LogoDbName = Configuration["LogoDbName"];
                string LogoFirmaNo = logofirmno.ToString("000");
                string sqlstring = "SELECT  LOGICALREF,  CODE,  DEFINITION_ from " + LogoDbName + ".[dbo].[LG_SLSMAN] with(nolock) WHERE ACTIVE=0 and (FIRMNR = -1 OR FIRMNR = " + LogoFirmaNo + ")";

                IEnumerable<PersonelDto> dbResponse;
                dbResponse = await db.QueryAsync<PersonelDto>(sqlstring, commandType: CommandType.Text);
                return dbResponse;
            }


        }
    }
}
