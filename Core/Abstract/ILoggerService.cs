namespace Core.Abstract
{
    public interface ILoggerService
    {
        void LogToDatabase(string key = null, params string[] args);
        void LogToFile(string key, params string[] args);
        void LogWarn(string key, params string[] args);
        void LogError(string key, params string[] args);
        void LogException(Exception exception, string message);
        void Logger(object requestData, object responseData);
    }
}
