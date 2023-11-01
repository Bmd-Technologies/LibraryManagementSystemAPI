namespace LibraryManagementSystemAPI.Shared.Logging
{
    public interface IAppLogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message, Exception ex);
        void LogError(string message, string exceptiondetails);
        void Flush();
    }
}
