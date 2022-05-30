using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Logging
{
    public class UmotaLoggerProvider : ILoggerProvider
    {
 

        public ILogger CreateLogger(string categoryName)
        {
            return new UmotaLogger();
        }

        public void Dispose()
        {
             
        }
    }

    public class UmotaLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logMsg = formatter(state, exception);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .Build();
            var connStr = configuration.GetConnectionString("LoggerConnection");
                       

            using (SqlConnection db = new SqlConnection(connStr))
            {
                db.Execute("insert into dbo.sis_logs (LogMessage) values ('" + logMsg + "')");
            }
        }
    }
}
