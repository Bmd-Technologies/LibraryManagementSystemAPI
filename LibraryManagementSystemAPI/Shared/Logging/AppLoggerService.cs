using NLog;

namespace LibraryManagementSystemAPI.Shared.Logging
{
    public class AppLoggerService : IAppLogger
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();



        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message, Exception ex)
        {
            logger.Error(ex, message);
        }
        public void LogError(string message, string exceptiondetails)
        {
            logger.Error(message, exceptiondetails);
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }



        public void Flush()
        {
            LogManager.Flush();
        }
    }
}
