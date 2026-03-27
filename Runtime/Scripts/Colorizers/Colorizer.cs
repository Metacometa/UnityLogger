using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Colorizers
{
    internal class Colorizer
    {
        public static void Colorize(LogData logData)
        {
            logData.Class = Colorize(logData.Class, "cyan");
            logData.Callback = Colorize(logData.Callback, "cyan");
            
            string methodColor = LoggerUnityCallbackHandler.IsUnityCallback(logData.Method) 
                ? "cyan" 
                : "white";

            logData.Method = Colorize(logData.Method, methodColor);

            ColorizerVisitor colorizerVisitor = new();
            logData.Message.Accept(colorizerVisitor);
        }

        public static string Colorize(string text, string color)
        {
            return string.IsNullOrEmpty(text) ? 
                    text : 
                    $"<color={color}>{text}</color>";
        }
    }
}