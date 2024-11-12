namespace LogXpress;

public class Logger : ILogger
{
    private readonly LoggerSettings _settings;

    public Logger(LoggerSettings settings)
    {
        _settings = settings;
    }

    private string FormatMessage(LogLevel level, string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var threadId = Thread.CurrentThread.ManagedThreadId;

        var formattedMessage = _settings.MessageFormat
            .Replace("{date}", timestamp)
            .Replace("{level}", level.ToString().ToUpper())
            .Replace("{threadId}", threadId.ToString())
            .Replace("{message}", message);

        return formattedMessage;
    }

    private void WriteLog(LogLevel level, string message)
    {
        // Проверка уровня логирования
        if (level < _settings.MinimumLogLevel) return;

        var formattedMessage = FormatMessage(level, message);

        // Запись в консоль
        if (_settings.LogToConsole)
        {
            Console.WriteLine(formattedMessage);
        }

        // Запись в файл
        if (_settings.LogToFile && !string.IsNullOrEmpty(_settings.LogFilePath))
        {
            System.IO.File.AppendAllText(_settings.LogFilePath, formattedMessage + Environment.NewLine);
        }
    }

    public void LogDebug(string message) => WriteLog(LogLevel.Debug, message);
    public void LogInfo(string message) => WriteLog(LogLevel.Info, message);
    public void LogWarning(string message) => WriteLog(LogLevel.Warning, message);
    public void LogError(string message) => WriteLog(LogLevel.Error, message);
    public void LogFatal(string message) => WriteLog(LogLevel.Fatal, message);
}