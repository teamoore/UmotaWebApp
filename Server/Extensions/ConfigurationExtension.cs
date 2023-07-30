using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetUmotaConnectionString(this IConfiguration configuration, string firmaId = null)
        {
            return configuration.GetConnectionString("UmotaConnection");

            //var dbname = configuration["masterDbName"];
            //var dbUser = configuration["masterDbUser"];
            //var dbPassword = configuration["masterDbPassword"];
            //var dbServer = configuration["masterServer"];

            //if (!string.IsNullOrEmpty(firmaId))
            //{
            //    string firmano = "00" + firmaId;
            //    dbname = dbname + "_" + firmano.Substring(firmano.Length- 3, 3);
            //}

            //return string.Format("Server={0};Database={1};user={2};password={3};",
            //    dbServer, dbname, dbUser, dbPassword);
        }

        public static string GetUmotaImageDbConnectionString(this IConfiguration configuration, string firmaId = null)
        {
            var dbname = configuration["masterDbName"];
            var dbUser = configuration["masterDbUser"];
            var dbPassword = configuration["masterDbPassword"];
            var dbServer = configuration["masterServer"];

            if (!string.IsNullOrEmpty(firmaId))
            {
                string firmano = "00" + firmaId;
                dbname = dbname + "_" + firmano.Substring(firmano.Length - 3, 3) + "_IMG";
            }

            return string.Format("Server={0};Database={1};user={2};password={3};",
                dbServer, dbname, dbUser, dbPassword);
        }

        public static string GetPrizmeDbConnection(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("PrizmaConnection");
        }

        public static string GetMasterDbConnection(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("UmotaConnection");
        }

        public static string GetUmotaObjectName(this IConfiguration configuration,string objectName, string firmaId = null)
        {
            var dbname = configuration["masterDbName"];
            
            if (!string.IsNullOrEmpty(firmaId))
            {
                string firmano = "00" + firmaId;
                dbname = dbname + "_" + firmano.Substring(firmano.Length - 3, 3);
            }

            return string.Format("[{0}].[dbo].[{1}]", dbname, objectName);
        }
    }
}
