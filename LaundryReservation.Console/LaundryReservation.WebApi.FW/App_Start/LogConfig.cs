using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaundryReservation.WebApi.FW.App_Start
{
    public class LogConfig
    {
        public static void ConfigureLog()
        {
            var log = new LoggerConfiguration()
            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            Log.Logger = log;
        }
    }
}