using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Formatters
{
    internal class LogFormatter
    {
        public static string Format(LogData logData)
        {
            return $"[{logData.Class}] [{logData.Method}]: {logData.Message.Token}";
        }
    }
}