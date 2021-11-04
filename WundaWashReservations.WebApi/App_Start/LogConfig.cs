using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WundaWashReservations.WebApi.App_Start
{
    public class LogConfig
    {
        public static void ConfigureLog()
        {
            var log = new LoggerConfiguration()
            .WriteTo.File(@"c:\logs\WundaWash.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Logger = log;
        }
    }
}