using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Formatters
{
    internal abstract class BaseFormatter
    {
        public string Format(LogData logData)
        {
            logData.Callback = FormatCallback(logData.Callback);
            
            return Build(logData);
        }

        protected abstract string FormatCallback(string text);
        protected abstract string Build(LogData logData);
    }
}