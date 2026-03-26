using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Formatters
{
    internal class BracketsFormatter : BaseFormatter
    {
        protected override string FormatCallback(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? $" " : $" [{text}] ";
        }

        protected override string Build(LogData logData)
        {
            return $"[{logData.Class}]{logData.Callback}[{logData.Method}]: {logData.Message.Token}";
        }
    }
}