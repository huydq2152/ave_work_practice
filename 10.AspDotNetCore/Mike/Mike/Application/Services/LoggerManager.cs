using Mike.Application.Share.Interface;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Mike.Application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
        }

        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
        }

        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }
    }
}
