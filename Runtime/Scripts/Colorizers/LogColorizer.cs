using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Colorizers
{
    internal class LogColorizer
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

        public static string FormatVariable(string text)
        {
            return Colorize(text, "yellow");
        }

        public static string FormatPunctuation(string text)
        {
            return Colorize(text, "white");
        }

        public static string FormatEquationResult(bool result)
        {
            return result ? Colorize(result.ToString(), "green") : Colorize(result.ToString(), "red");
        }

        public static string Colorize(string text, string color)
        {
            return $"<color={color}>{text}</color>";
        }
    }
}