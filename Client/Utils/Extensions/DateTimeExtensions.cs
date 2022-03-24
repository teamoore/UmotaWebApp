using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public static class DateTimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, TimeSpan? timeSpan)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                timeSpan.Value.Hours,
                timeSpan.Value.Minutes,
                timeSpan.Value.Seconds,
                timeSpan.Value.Milliseconds,
                dateTime.Kind);
        }

        public static TimeSpan GetTime(this DateTime dateTime)
        {
            return new TimeSpan(0, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }
    }
}
