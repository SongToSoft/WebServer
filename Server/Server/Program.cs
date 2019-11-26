using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using LogLevel = NLog.LogLevel;

namespace Server
{
    public class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "ServerRun.log" };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
            logger.Info("Logger is Configured");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            logger.Info("Create Web Host Builder ");
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}
