namespace LogXpress;

public class LoggerSettings
{
    // Минимальный уровень логирования, при котором сообщения будут записываться
    public LogLevel MinimumLogLevel { get; set; } = LogLevel.Info;

    // Путь к файлу для записи логов
    public string LogFilePath { get; set; } = "logs.txt";

    // Формат сообщений логирования (например, "{date} - {level} - {threadId} - {message}")
    public string MessageFormat { get; set; } = "{date} - {level} - {threadId} - {message}";

    // Опция для вывода логов в консоль
    public bool LogToConsole { get; set; } = true;

    // Опция для вывода логов в файл
    public bool LogToFile { get; set; } = true;
    
    // Пример: добавление других параметров
    public bool IncludeExceptionDetails { get; set; } = true;
}
