// See https://aka.ms/new-console-template for more information

using LogXpress;



var settings = new LoggerSettings
{
    MinimumLogLevel = LogLevel.Debug,    // Логи с уровнем ниже Warning не будут записываться
    LogFilePath = "application_logs.txt",  // Путь к файлу для записи
    LogToConsole = true,                   // Выводить логи в консоль
    LogToFile = true                       // Записывать логи в файл
};

var logger = new Logger(settings);

logger.LogInfo("This is an info message.");    // Будет проигнорировано, так как уровень ниже Warning
logger.LogWarning("This is a warning message"); // Будет записано
logger.LogError("This is an error message");   // Будет записано